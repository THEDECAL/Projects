using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите целое число больше 0: ");
            uint number = Convert.ToUInt32(Console.ReadLine());
            uint reverseNumber = 0;

            start:
            reverseNumber += number % 10;
            number /= 10;
            if (number != 0)
            {
                reverseNumber *= 10;
                goto start;
            }

            Console.WriteLine($"Реверс вашего числа: {reverseNumber}");
        }
    }
}
