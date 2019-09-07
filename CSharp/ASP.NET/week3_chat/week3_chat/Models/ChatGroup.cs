using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week3_chat.Models
{
    public class ChatGroup
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public List<ChatUser> Owners { get; set; } = new List<ChatUser>();
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }
}