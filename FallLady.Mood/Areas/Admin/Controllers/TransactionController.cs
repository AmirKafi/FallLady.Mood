using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Dto.Teacher;
using FallLady.Mood.Application.Contract.Interfaces.Transactions;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class TransactionController : BaseController
    {
        #region Constructor
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }
        #endregion

        [Route("/Transaction/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Transaction";

            return View();
        }

        [Route("/Transaction/LoadTransactions")]
        public async Task<ActionResult> LoadTeachers(BaseDto dto)
        {
            var data = await _service.GetTransactions(dto).ConfigureAwait(false);
            if (data.ResultStatus == ResultStatus.Successful)
                data.Data.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Transaction));

            return Json(data);
        }

        [HttpPost]
        [Route("/Transaction/Confirmation")]
        public async Task<ActionResult> Confirmation(int transactionId , bool confirm)
        {
            ViewBag.ActivePage = "Transaction";

            var result = await _service.TransactionConfirmation(transactionId,confirm).ConfigureAwait(false);

            return Json(result);
        }
    }
}
