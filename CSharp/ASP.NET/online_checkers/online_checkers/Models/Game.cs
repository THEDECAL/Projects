using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Security.Claims;

namespace online_checkers.Models
{
    public class Game
    {
        public CheckersBoard Board { get; private set; }
        public GamePlayer FirstPLayer { get; set; } = new GamePlayer();
        public GamePlayer SecondPlayer { get; set; } = null;
        public string Winner { get; set; } = "";
        public DateTime DateStart { get; private set; } = DateTime.Now;
        public DateTime DateFinish { get; set; }
        public Game(BoardSize size = BoardSize._8x8)
        {
            this.Board = new CheckersBoard(size);
        }
    }
}
