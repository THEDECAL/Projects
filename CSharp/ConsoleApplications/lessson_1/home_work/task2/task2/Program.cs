using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main()
        {
            decimal contribution = 10000M;
            Console.Write("Введите процентную ставку (вводите дробное число через запятую): ");
            decimal rate = Convert.ToDecimal(Console.ReadLine());

            uint cntMonthes = 0;
            for (;;)
            {
                if (contribution >= 11000M) break;
                contribution += (contribution / 100M) * rate;
                cntMonthes++;
            }

            Console.WriteLine($"Кол-во месяцев для достижения вклада 11000 грн.: {cntMonthes}");
            Console.WriteLine($"Итоговый капитал: {contribution} грн.");
        }
    }
}
