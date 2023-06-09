using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];

        public AccountController(
            ILogger<AccountController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangeUserAuth()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserAuth(UserAuth userAuth)
        {
            _logger.LogInformation($"userAuth Info:{JsonConvert.SerializeObject(userAuth)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.UserAuth.Add(userAuth);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{userAuth.UserGuid} userAuth added successfully.");
                    var result = await _unitOfWork.UserAuth.ChangeUserAuth(userAuth, baseURL);

                    return View(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return new JsonResult(ex.Message) { StatusCode = 500 };
                }
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

            return new JsonResult(errors);
        }
    }
}
