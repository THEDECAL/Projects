using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public void Copy(Ticket ticket)
        {
            Title = ticket.Title;
            Comments = ticket.Comments;
            UserId = ticket.UserId;
            User = ticket.User;
        }
    }
}
