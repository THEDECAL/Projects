using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlinePoker.Models;

namespace OnlinePoker.Controllers
{
    public class ValidationController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ValidationController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult IsEmailNotExist([Bind(Prefix = "Input.Email")]string email)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email.Equals(email));
            if (user != null) return Json($"Такой электронный адрес ({email}) уже существует, введите другой адрес.");
            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult IsNickNameNotExist([Bind(Prefix = "Input.NickName")]string nickName)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.NickName.Equals(nickName));
            if (user != null) return Json($"Такой ник ({nickName}) уже существует, введите другой ник.");
            return Json(true);
        }
    }
}