using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Models.Pocos
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Profile SourceProfile { get; set; }
        public Profile DestinationProfile { get; set; }
        public double Amount { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
    }
}