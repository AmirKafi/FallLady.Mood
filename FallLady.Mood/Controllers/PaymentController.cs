using FallLady.Mood.Application.Contract.Dto.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class PaymentController : BaseController
    {
        #region Constructor
        private readonly ITransactionService _service;
        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public PaymentController(ITransactionService service, IConfiguration configuration, IOrderService orderService, IUserService userService)
        {
            _service = service;
            _configuration = configuration;
            _orderService = orderService;
            _userService = userService;
        }
        #endregion

        [HttpGet]
        [Route("/BankTransfer")]
        public async Task<ActionResult> BankTransfer(string ordersId)
        {
            var dto = new TransactionCreateDto();

            var result = new ServiceResponse<int>();

            List<int> orders = new List<int>();

            foreach (var item in ordersId.Split(',').ToList())
            {
                orders.Add(Convert.ToInt32(item));
            }
            dto.OrdersStr = ordersId;
            dto.OrdersId = orders;

            var userId = await _userService.GetUserId(User);
            var order = await _orderService.LoadOrders(userId.Data).ConfigureAwait(false);

            dto.DiscountPrice = order.Data.Sum(x => x.OrderType == FormEnum.Course ? (x.Course.DiscountPrice.HasValue ? x.Course.DiscountPrice.Value : 0) : 0);
            dto.TotalPrice = order.Data.Sum(x=> x.Course is null ? 0 : x.Course.Price * x.Qty);

            dto.PaymentType = PaymentTypesEnum.BankTransfer;

            return PartialView(dto);
        }

        [HttpPost]
        [Route("/Pay")]
        public async Task<ActionResult> Pay(TransactionCreateDto dto)
        {
            var userId = await _userService.GetUserId(User);
            var result = new ServiceResponse<int>();

            List<int> orders = new List<int>();

            foreach (var item in dto.OrdersStr.Split(',').ToList())
            {
                orders.Add(Convert.ToInt32(item));
            }
            dto.OrdersId = orders;

            if (dto.PaymentType == PaymentTypesEnum.BankTransfer)
            {
                dto.PaymentCode = "0";
                dto.PaymentResult = "200";
                dto.PaymentResultDescription = "پرداخت از طریق کارت به کارت و فیش بانکی";
                dto.PaymentState = PaymentStatesEnum.WaitingForConfirmation;

                if (dto.ReceiptImageFile != null)
                {
                    var fileName = SaveFile(dto.ReceiptImageFile, FileFoldersEnum.Transaction);
                    dto.ReceiptImage = fileName.Data;
                }
                else
                {
                    var res = new ServiceResponse<bool>();
                    res.SetException("آپلود رسید اجباری می باشد");
                    return Json(res);
                }
            }


            result = await _service.Pay(dto);
            if (result.ResultStatus == ResultStatus.Successful)
            {

                await _orderService.Pay(dto.OrdersId, result.Data);
            }

            if (result.ResultStatus == ResultStatus.Successful)
                await _orderService.RefreshOrders(userId.Data);

            return Json(result);
        }
    }
}
