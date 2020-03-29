using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите два числа где A < B.");
            Console.Write("Введите A: ");
            uint start = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введите B: ");
            uint finish = Convert.ToUInt32(Console.ReadLine());

            if(start >= finish) Console.WriteLine("Числа либо равны или первое больше второго.");
            
            start:
            for (uint i = 1; i <= start; i++) Console.Write($"{start} ");
            start++;
            Console.Write("\n");
            if(start <= finish) goto start;
        }
    }
}
