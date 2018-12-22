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
            int rmin = 0, rmax = 9, size = 0;
            int[] first, second, third = new int[0];

            //Ввод 1-го массив
            Console.Write("Введите размер первого массива: ");
            size = Convert.ToInt32(Console.ReadLine());
            first = new int[size];

            Console.WriteLine("Элементы первого массива:");
            for (int i = 0; i < first.Length; i++)
            {
                first[i] = rnum.Next(rmin, rmax);
                Console.Write($"{first[i]}\t");
            }
            Console.WriteLine("\n");
            
            //Ввод 2-го массив
            Console.Write("Введите размер второго массива: ");
            size = Convert.ToInt32(Console.ReadLine());
            second = new int[size];

            Console.WriteLine("Элементы второго массива:");
            for (int i = 0; i < second.Length; i++)
            {
                second[i] = rnum.Next(rmin, rmax);
                Console.Write($"{second[i]}\t");
            }
            Console.WriteLine("\n");

            size = 0;

            foreach (int i in first)
            {
                foreach (int j in second)
                {
                    if (i == j)
                    {
                        bool isCoincedence = false;
                        foreach (int k in third)
                            if (i == k) isCoincedence = true;
                        if (isCoincedence == false)
                        {
                            Array.Resize(ref third, (int)(size += 1));
                            third[size - 1] = i;
                        }
                    }
                    else continue;
                }
            }

            if (third.Length != 0)
            {
                Console.WriteLine("Общие элементы двух массивов:");
                foreach (int i in third) Console.Write($"{i}\t");
            }
            else Console.WriteLine("Общих элементов нет.");
            Console.WriteLine();

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
