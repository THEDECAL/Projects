using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Models.Pocos
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public int AmountOfTraffic { get; set; } = 0;
        public int BandwidthInput { get; set; } = 100000;
        public int BandwidthOutput { get; set; } = 100000;
        public int AmounfOfDays { get; set; } = 28;
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfUpdate { get; set; } = DateTime.Now;
        public bool IsEnabled { get; set; } = false;
    }
}