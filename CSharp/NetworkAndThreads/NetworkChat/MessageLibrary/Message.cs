using System;

namespace MessageLibrary
{
    public enum MsgType { USER_ADD, USER_DEL, MSG, PRIVATE_MSG };
    public class Message
    {
        public string Text { get; set; }
        public MsgType Type { get; set; }
        public string OwnerUserName { get; set; }
        public string RecipientUserName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Message() { }
    }
}
