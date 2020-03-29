using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlinePoker.Models;

namespace OnlinePoker.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            //[Phone]
            //[Display(Name = "Phone number")]
            //public string PhoneNumber { get; set; }
            [Display(Name = "Почтовый адрес")]
            [Remote(action: "IsEmailNotExist", controller: "Validation")]
            public string Email { get; set; }
            [Display(Name = "Никнэйм")]
            [Remote(action: "IsNickNameNotExist", controller: "Validation")]
            public string NickName { get; set; }
            [Display(Name = "Сумма монет")]
            public int CoinsAmount { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var account = await _userManager.GetUserAsync(User);

            Username = userName;

            Input = new InputModel
            {
                //PhoneNumber = phoneNumber
                Email = account.Email,
                NickName = account.NickName,
                CoinsAmount = account.CoinsAmount
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.NickName != user.NickName)
            {
                user.NickName = Input.NickName;
                var result = await _userManager.UpdateAsync(user);
            }
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        var userId = await _userManager.GetUserIdAsync(user);
            //        throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
            //    }
            //}

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш профайл обновлён";
            return RedirectToPage();
        }
    }
}
