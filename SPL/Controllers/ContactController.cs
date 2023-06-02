using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPL.IConfiguration;
using SPL.Models;

namespace SPL.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        string baseURL = AppConfigurations.AppSetting["ApiSettings:CrmBaseURL"];

        public ContactController(
            ILogger<ContactController> logger,
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
        public async Task<IActionResult> Create(Contact contact)
        {
            _logger.LogInformation($"Contact Info:{JsonConvert.SerializeObject(contact)}");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Contact.Add(contact);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation($"{contact.EnglishName} contact added successfully.");
                    var result = await _unitOfWork.Contact.CreateContact(contact, baseURL);

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
