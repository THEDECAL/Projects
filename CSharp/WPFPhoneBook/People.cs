using System;
using System.Drawing;

namespace WPFPhoneBook
{
    public class People
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public string PName { get; set; }
        public string PhoneNumber { get; set; }
        public string PathToImage { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public override string ToString() => $"{FName} {PName}";
    }
}
