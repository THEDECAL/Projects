using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main()
        {
            start:
            Console.Clear();

            Random rnum = new Random();
            int rmin = -100, rmax = 100;
            int[,] array = new int[5, 5];

            //Генерация чисел и их вывод на экран
            Console.WriteLine("Сгенерированный многомерный массив псевдослучайных чисел: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnum.Next(rmin,rmax);
                    Console.Write(array[i,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            
            //Поиск максимального и минимального числа
            int max = rmin, min = rmax;
            foreach (int i in array)
            {
                if (i > max) max = i;
                if (i < min) min = i;
            }

            //Подсчёт суммы между min и max
            int sum = 0;
            bool isStartOfSum = false;
            foreach (int i in array)
            {
                if (i == max) isStartOfSum = false;
                if (isStartOfSum == true) sum += i;
                if (i == min) isStartOfSum = true;
            }

            Console.WriteLine($"Сумма чисел между минимальным ({min}) и максимальным числом ({max}): {sum}");

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
