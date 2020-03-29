using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ConfirmationCode { get; set; }
        public override bool Equals(object obj)
        {
            var user = obj as User;
            return Email == user.Email && Password == user.Password;
        }
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => Email;
    }
}
