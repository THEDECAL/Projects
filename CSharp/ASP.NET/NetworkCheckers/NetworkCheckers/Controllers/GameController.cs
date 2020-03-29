using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetworkCheckers.Data;
using NetworkCheckers.Models;
using NetworkCheckers.Models.Hubs;

namespace NetworkCheckers.Controllers
{
    public class GameController : Controller
    {
        readonly UserManager<User> _userManager;
        public GameController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            GameHub.IsNewGame = true;
            return View(GameHub.NewGame);
        }
        [Authorize]
        public IActionResult Continue()
        {
            Game game = null;
            var currUser = _userManager.Users
                .FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);

            if (currUser != null)
            {
                using (ApplicationDbContext.DbContext)
                {
                    game = ApplicationDbContext.DbContext.Games
                        .LastOrDefault(g => g.WinnerPlayerId == null && (g.WhitePlayerId == currUser.Id || g.BlackPlayerId == currUser.Id));
                }
            }

            GameHub.IsNewGame = false;
            return View(game);
        }
    }
}