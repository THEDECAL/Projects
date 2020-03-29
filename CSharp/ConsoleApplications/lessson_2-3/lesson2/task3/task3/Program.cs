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

            Random rnum = new Random();
            int rmin = 0, rmax = 9;

            const uint size = 15;
            uint[] array = new uint[size];

            //Генерация чисел массива
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (uint)rnum.Next(rmin, rmax);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            //Ввод числа
            int num;
            Console.Write("Введите число для поиска в массиве: ");
            num = Convert.ToInt32(Console.ReadLine());

            //Подсчёт совпадений
            int counter = 0;
            foreach (var item in array) if (num == item) counter++;

            //Вывод результата
            Console.WriteLine($"Кол-во совпадений числа {num}: {counter}");

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
