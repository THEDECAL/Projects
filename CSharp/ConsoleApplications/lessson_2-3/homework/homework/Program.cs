using System;

namespace homework
{
    partial class pc
    {
        public static uint AmoutPcOnStock;
        public static string ShopName;
        public string PcBrand { get; set; }
        public string CpuBrand { get; set; }
        public ushort CpuFrequency { get; set; }
        public string RamBrand { get; set; }
        public ushort RamMemoryAmount { get; set; }
        public string HddBrand { get; set; }
        public ushort HddMemoryAmount { get; set; }
        public decimal Price { get; set; }
        public pc()
        {
            PcBrand = CpuBrand = RamBrand = HddBrand = "Не задано.";
            CpuFrequency = RamMemoryAmount = HddMemoryAmount = 0;
            Price = 0.0m;
        }
        public pc(ref string pc_brand, ref decimal price)
        {
            PcBrand = pc_brand;
            Price = price;
        }
        public pc(
            string pc_brand,
            string cpu_brand,
            ushort cpu_frequency,
            string ram_brand,
            ushort ram_memory_amount,
            string hdd_brand,
            ushort hdd_memory_amount,
            decimal price)
        {
            PcBrand = pc_brand;
            CpuBrand = cpu_brand;
            CpuFrequency = cpu_frequency;
            RamBrand = ram_brand;
            RamMemoryAmount = ram_memory_amount;
            HddBrand = hdd_brand;
            HddMemoryAmount = hdd_memory_amount;
            Price = price;
        }
        static pc()
        {
            pc.ShopName = "Rozetka";
        }
    }
    class Program
    {
        static void Main()
        {
            pc.ShopName = "Rozetka";
            pc.AmoutPcOnStock = 302;

            pc[] array = 
            {
                new pc(),
                new pc("Dell","Intel",3800,"Kingston",4096,"Samsung",1000,8238),
                new pc("HP","Intel",2800,"SiliconPower",4096,"Hitachi",500,5700),
                new pc("Fujitsu","AMD",3800,"Kingston",8192,"Western Digital",2000,15800),
                new pc("Dell","Intel",2900,"Kingston",4096,"Samsung",500,9800)
            };

            foreach (var item in array) item.show();
        }
    }
}
