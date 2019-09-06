using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week3_chat.Models
{
    public class ChatUser
    {
        public string Id { get; set; }
        public string ConnectionId { get; set; }
        public string Name { get; set; } = "";
    }
}