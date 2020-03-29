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
            start:
            Console.Clear();

            Console.Write("Введите строку: ");
            string line = Console.ReadLine();

            bool isEquals = true;
            for (int i = 0, j = line.Length - 1; i < line.Length / 2;) 
                if (line[i++] != line[j--]) isEquals = false;

            Console.WriteLine($"Строка{(isEquals == true ? " " : " не ")}является полиндромом.");

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
