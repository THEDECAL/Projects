using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Attributes
{
    public class MenuPositionAttribute : Attribute
    {
        public int Position { get; private set; }
        public MenuPositionAttribute(int position)
        {
            Position = position;
        }
    }
}
