using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main()
        {
            for (;;)
            {
                string text = File.ReadAllText("текст.txt", Encoding.UTF8);
                Console.Write("\nВведите слово для поиска: ");
                string word = Console.ReadLine();
                string pattern = $"{word}";

                MatchCollection m = Regex.Matches(text, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                Console.WriteLine($"Кол-во совпадений данного слова: {m.Count}");

                Console.WriteLine("Нажмите любую клавишу для продолжения или Ctrl + C для завершения.");
                Console.ReadKey();
            }
        }
    }
}
