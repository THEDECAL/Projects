using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main()
        {
            for (;;)
            {
                Console.WriteLine("Введите номер телефона в формате +[код страны]-[код оператора/города]-[номер телефона]: ");
                string telNum = Console.ReadLine();

                string pattern = @"\+?\d{1,3}[ -]\d{2,6}[ -]\d{2,9}";

                Console.WriteLine($"Введённый телефон {(Regex.IsMatch(telNum, pattern) ? "валидный" : "не валидный")}.");

                Console.WriteLine("Нажмите любую клавишу для продолжения или Ctrl + C для завершения.");
                Console.ReadKey();
            }
        }
    }
}
