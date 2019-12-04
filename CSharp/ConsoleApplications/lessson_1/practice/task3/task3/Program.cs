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
            string[] hundreds = { "Сто", "Двести", "Триста", "Четыриста", "Пятьсот", "Шестьсот", "Семьсот", "Восемсот", "Девятьсот" };
            string[] tens = { "двадцать", "тридцать", "сорок", "пятдесят", "шестдесят", "семьдесят", "восемдесят", "девяносто" };
            string[] ex_units = { "одинадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] units = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять" };

            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 99 && number < 1000)
            {
                Console.Write($"{hundreds[(number / 100) - 1]} ");
                number %= 100;
                if (number > 10 && number < 20) Console.Write($"{ex_units[number - 11]}");
                else if (number > 0 && number <= 10) Console.Write($"{units[number - 1]}");
                else if (number > 20) Console.Write($"{tens[number / 10 - 2]} {units[(number % 10) - 1]}");
                Console.WriteLine("\n");
            }
            else Console.WriteLine("Число больше 1000 или меньше 100.");
        }
    }
}
