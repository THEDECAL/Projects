using EasyBilling.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.ViewModels
{
    public class NavigationBarViewModel
    {
        public string[] Menu { get; private set; }
        public NavigationBarViewModel(string[] menu)
        {
            Menu = menu;
        }
    }
}
