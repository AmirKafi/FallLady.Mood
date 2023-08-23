using FallLady.Mood.Application.Contract.Dto.Configs;
using FallLady.Mood.Application.Contract.Interfaces.Configs;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class ConfigController : BaseController
    {
        #region Constructor

        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        #endregion

        [HttpGet]
        [Route("/Config/ContactUsConfig")]
        public async Task<ActionResult> ContactUsConfig()
        {
            var config = await _configService.GetConfig();
            var model = new ConfigSaveDto();

            if(config.ResultStatus == ResultStatus.Successful)
            {
                model.Email = config.Data.Email;
                model.Address = config.Data.Address;
                model.ContactNumber = config.Data.ContactNumber;
            }

            return View(model);
        }

        [HttpPost]
        [Route("/Config/ContactUsConfig")]
        public async Task<ActionResult> ContactUsConfig(ConfigSaveDto dto)
        {
            var config = await _configService.SaveConfig(dto);

            return Json(config);
        }
    }
}
