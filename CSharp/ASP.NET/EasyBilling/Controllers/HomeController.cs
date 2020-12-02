using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using EasyBilling.Attributes;
using EasyBilling.Models;
using System.ComponentModel;

namespace EasyBilling.Controllers
{
    [Authorize]
    [NoShowToMenu]
    [DisplayName("Главная")]
    [MenuPosition(0)]
    public class HomeController : CustomController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }

        public IActionResult ErrorAccess(string id)
        {
            ViewData["Title"] = "Отказано в доступе";
            return View(model: id);
        }
    }
}
