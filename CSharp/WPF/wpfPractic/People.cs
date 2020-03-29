using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfPractic
{
    public class People : ICloneable
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Want { get; set; } = "";
        public object Clone()
        {
            return new People
            {
                Name = this.Name,
                Email = this.Email,
                Phone = this.Phone,
                Gender = this.Gender,
                Want = this.Want
            };
        }
        public void Clear()
        {
            Name = "";
            Email = "";
            Phone = "";
            Gender = "";
            Want = "";
        }
        public override string ToString() => Name;
    }
}
