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
            start:
            Console.Clear();

            Console.Write("Введите строку: ");
            string line = Console.ReadLine();

            string[] words = line.Split(" .,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //foreach (string i in words) Console.WriteLine(i);
            Console.WriteLine($"Кол-во слов в введённой строке: {words.Length}");

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
