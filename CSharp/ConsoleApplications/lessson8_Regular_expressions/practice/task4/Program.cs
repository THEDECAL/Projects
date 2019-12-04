using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main()
        {
            string fileName = "текст.txt";
            string text = File.ReadAllText(fileName, Encoding.UTF8);

            Console.Write("Введите слово для поиска: ");
            string wordToSearch = Console.ReadLine();
            Console.Write("Введиите слово для замены: ");
            string wordToReplace = Console.ReadLine();
            
            string newText = Regex.Replace(text, wordToSearch, wordToReplace, RegexOptions.Multiline);

            File.WriteAllText($"new_{fileName}", newText, Encoding.UTF8);
        }
    }
}
