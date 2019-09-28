using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_checkers.Models;
using online_checkers.Models.Hubs;

namespace online_checkers.Controllers
{
    public class GameController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (GameHub.newGame == null) {
                GameHub.newGame = new Game();
            }

            return View(newGame);
        }

        [Authorize]
        public IActionResult ListGames()
        {
            return View(GameHub.Games);
        }
    }
}