using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_checkers.Models.Hubs
{
    public class GameHub : Hub
    {
        static List<GamePlayer> users = new List<GamePlayer>();
        static public List<Game> Games { get; set; } = new List<Game>();
        static public Game newGame { get; set; } = null;

        public override Task OnConnectedAsync()
        {


            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {


            return base.OnDisconnectedAsync(exception);
        }
    }
}
