using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main()
        {
            for (;;)
            {
                Console.Write("\nВведите URL адрес: ");
                string URL = Console.ReadLine();
                //string pattern = @"(.+\/\/)?(?<domain>.+?)\/";
                string pattern = @"((.*\/\/)*(?<domain>([a-zA-Z0-9-_]+)(\.[a-zA-Z0-9-_]+)+)(\/*.*)*)";

                Console.Write("Домен введённого URL: ");
                Console.WriteLine($"{Regex.Match(URL, pattern).Groups["domain"]}");

                Console.WriteLine("Нажмите любую клавишу для продолжения или Ctrl + C для завершения.");
                Console.ReadKey();
            }
        }
    }
}
