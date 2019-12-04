using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    partial class pc
    {
        public void show()
        {
            Console.WriteLine("Производитель ПК: " + PcBrand);
            Console.WriteLine("Производитель ЦПУ: " + CpuBrand);
            Console.WriteLine($"Часота ЦПУ: {CpuFrequency} МГц");
            Console.WriteLine("Производитель ОЗУ: " + RamBrand);
            Console.WriteLine($"Объём ОЗУ: {RamMemoryAmount} МБ");
            Console.WriteLine("Производитель жесткого диска: " + HddBrand);
            Console.WriteLine($"Объём жесткого диска: {HddMemoryAmount} ГБ");
            Console.WriteLine($"\nЦена: {Price} грн.");
            Console.WriteLine("\n");
        }
    }
}
