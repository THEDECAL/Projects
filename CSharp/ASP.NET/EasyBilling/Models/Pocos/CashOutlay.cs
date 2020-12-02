using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Models.Pocos
{
    public class CashOutlay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Amount { get; set; } = 0;
        public Profile SourceProfile { get; set; }
        public Profile DestinationProfile { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}