using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main()
        {
            for(;;)
            {
                Console.WriteLine("\nВведите e-mail адрес для проверки на валидность: ");
                string email = Console.ReadLine();

                Regex rex = new Regex(@"^(\w+[-_.]?)+@(\w+[-_.]?)+");
                Console.WriteLine($"E-Mail {(rex.IsMatch(email) ? "валидный" : "не валидный" )}");

                Console.WriteLine("Нажмите любую клавишу для продолжения или Ctrl + C для завершения.");
                Console.ReadKey();
            }
        }
    }
}
