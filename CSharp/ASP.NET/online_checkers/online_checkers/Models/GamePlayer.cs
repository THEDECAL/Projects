using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace online_checkers.Models
{
    public class GamePlayer
    {
        public string ConnectionId { get; set; } = "";
        public string Name { get; private set; } = ClaimsPrincipal.Current.Identity.Name;
        public int ScorePoints { get; set; } = 0;
    }
}
