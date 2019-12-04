using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main()
        {
            start:
            Console.Clear();

            Random rnum = new Random();
            int rmin = -100;
            int rmax = 100;

            const uint size = 15;
            int[] array = new int[size];
            
            //Генерация чисел в массив
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnum.Next(rmin,rmax);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            //Пузырьковая сортировка
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            //Показ упорядоченного массива
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
