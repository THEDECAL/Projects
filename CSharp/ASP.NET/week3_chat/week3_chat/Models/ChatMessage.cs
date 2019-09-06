using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week3_chat.Models
{
    public class ChatMessage
    {
        DateTime date;
        public DateTime Date
        {
            get => date.ToLocalTime();
            set
            {
                date = value;
            }
        }
        public string Text { get; set; }
        public ChatUser Owner { get; set; }
    }
}