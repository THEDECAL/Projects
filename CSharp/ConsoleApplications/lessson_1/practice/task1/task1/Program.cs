using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите температуру в Фаренгейтах: ");
            int tf = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Температура в Цельсиях: {(tf - 32) * 5 / 9}");
        }
    }
}
