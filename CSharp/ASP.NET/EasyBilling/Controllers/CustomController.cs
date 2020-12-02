using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class CustomController : Controller
    {
        public string DisplayName { get; }
        public CustomController()
        {
            var temp = GetType();
            DisplayName = (GetType()
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .SingleOrDefault() as DisplayNameAttribute).DisplayName;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = DisplayName;
            return View();
        }
    }
}
