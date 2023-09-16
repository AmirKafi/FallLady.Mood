using FallLady.Mood.Application.Contract.Dto.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Controllers.Base;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Pay")]
        public async Task<ActionResult> Pay(List<int> ordersId,decimal totalPrice,decimal discountPrice)
        {
            var userId = await _userService.GetUserId(User);
            var isDevMode = _configuration.GetValue<bool>("DeveloperMode");
            var result = new ServiceResponse<bool>();
            var model = new TransactionCreateDto();

            if(isDevMode)
            {
                model.OrdersId = ordersId;
                model.TotalPrice = totalPrice;
                model.DiscountPrice = discountPrice;
                model.PaymentCode = "Test";
                model.PaymentResult = "200";
                model.PaymentResultDescription = "Test";

               result =  await _service.Pay(model);
            }

            if (result.ResultStatus == ResultStatus.Successful)
                await _orderService.RefreshOrders(userId.Data);

            return Json(result);
        }
    }
}
