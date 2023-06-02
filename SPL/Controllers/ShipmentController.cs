using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly ILogger<ShipmentController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];

        public ShipmentController(
            ILogger<ShipmentController> logger,
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shipment shipment)
        {
            _logger.LogInformation($"Shipment Info:{JsonConvert.SerializeObject(shipment)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Shipment.Add(shipment);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{shipment.Name} shipment added successfully.");
                    var result = await _unitOfWork.Shipment.CreateShipment(shipment, baseURL);

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
