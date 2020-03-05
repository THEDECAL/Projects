using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePoker.Hubs;

namespace OnlinePoker.Controllers
{
    public class GameController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult NewGame(int amountPlayers)
        {
            try
            {
                var game = new Models.Game(amountPlayers);
                PokerHub.ListGames.Add(game);

                return RedirectToAction("StartGame", "Game", new { game.Id });
            }
            catch (Exception) { return View("Error"); }
        }

        [Authorize]
        [HttpGet]
        public IActionResult StartGame(string Id)
        {
            if (Id != null && Id.Trim().Length != 0)
            {
                var game = PokerHub.ListGames.FirstOrDefault(g => g.Id == Id);

                return View(Id as Object);
            }

            return View("Error");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CurrentGames() => View(PokerHub.ListGames);

        [HttpGet]
        public IActionResult Rules() => View();

        [HttpGet]
        public IActionResult Combinations() => View();
    }
}