using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class BranchController : Controller
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];
        public BranchController(
            ILogger<BranchController> logger,
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
        public async Task<IActionResult> Create(Branch branch)
        {
            _logger.LogInformation($"Branch Info:{JsonConvert.SerializeObject(branch)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Branch.Add(branch);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{branch.Name} branch added successfully.");
                    var result = await _unitOfWork.Branch.CreateBranch(branch, baseURL);

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
