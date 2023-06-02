using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class ProspectController : Controller
    {
        private readonly ILogger<ProspectController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];

        public ProspectController(
            ILogger<ProspectController> logger,
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

        [HttpPost]
        public async Task<IActionResult> Create(Prospect prospect)
        {
            _logger.LogInformation($"Prospect Info:{JsonConvert.SerializeObject(prospect)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Prospect.Add(prospect);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{prospect.CompanyNameEnglish} prospect added successfully.");
                    var result = await _unitOfWork.Prospect.CreateProspect(prospect, baseURL);

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
