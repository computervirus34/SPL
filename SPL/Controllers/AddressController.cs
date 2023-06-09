using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];
        public AddressController(
            ILogger<AddressController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Create(PinCodeModel pinCodeModel)
        {
            _logger.LogInformation($"PinCodeModel Info:{JsonConvert.SerializeObject(pinCodeModel)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.PinCode.Add(pinCodeModel);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{pinCodeModel.StoreId} pinCodeModel added successfully.");
                    var result = await _unitOfWork.PinCode.GetPinCode(pinCodeModel, baseURL);

                    if (string.IsNullOrEmpty(result.PinCode))
                    {
                        await _unitOfWork.PinCode.Update(result);

                        var addressDetails = await _unitOfWork.UPDSGenericResult.GetAddresses(pinCodeModel, baseURL);

                        foreach(var item in addressDetails.waselAddressDetails)
                        {
                           await _unitOfWork.UPDSGenericResult.Add(item);
                        }
                    }

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
