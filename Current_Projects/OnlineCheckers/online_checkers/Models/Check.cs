using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace online_checkers.Models
{
    public enum CheckType { Men, King }
    public enum CheckColor { None, White, Black };
    public class Check
    {
        public CheckType Type { get; set; } = CheckType.Men;
        public CheckColor Color { get; set; } = CheckColor.None;
        public override string ToString()
        {
            return $"{Enum.GetName(typeof(CheckType), Type)}, {Enum.GetName(typeof(CheckColor), Color)}";
        }
    }
}
