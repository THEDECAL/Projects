using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class PC
    {
        public string Brand { get; set; }
        public int CPUFrequency { get; set; }
        public int RAMSpace { get; set; }
        public int HDDSpace { get; set; }
        public PC()
        {
            Brand = "-Не задано-";
            CPUFrequency = RAMSpace = HDDSpace = 0;
        }
        public PC(string brand = "-Не задано-", int cpu = 0, int ram = 0, int hdd = 0)
        {
            Brand = brand;
            CPUFrequency = cpu;
            RAMSpace = ram;
            HDDSpace = hdd;
        }
        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.Append($"Компания производитель: {Brand}\n");
            description.Append($"Частота ЦПУ: {(CPUFrequency == 0 ? "- Не задано -" : CPUFrequency.ToString())}МГц\n");
            description.Append($"Объём ОЗУ: {(RAMSpace == 0 ? "- Не задано -" : RAMSpace.ToString())}МГц\n");
            description.Append($"Объём диска: {(HDDSpace == 0 ? "- Не задано -" : HDDSpace.ToString())}МГц\n");

            return description.ToString();
        }
        public string Start()
        {
            return "Включение";
        }
        public string Shutdown()
        {
            return "Выключение";
        }
        public string Restart()
        {
            return "Перезагрузка";
        }
    }
}
