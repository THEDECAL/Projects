using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main()
        {
            start:
            Console.Clear();

            Random rnum = new Random();
            int rmin = 0, rmax = 9;

            int rows = 3,cols = 5;
            int[,] marray = new int[rows,cols];

            //Генерация чисел массива
            for (int i = 0; i < marray.GetLength(0); i++)
            {
                for (int j = 0; j < marray.GetLength(1); j++)
                {
                    marray[i, j] = rnum.Next(rmin,rmax);
                    Console.Write(marray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            //Меняем местами столбцы, первый с последним и т.д.
            for (int i = 0; i < marray.GetLength(0); i++)
            {
                for (int j = 0; j < marray.GetLength(1) / 2; j++)
                {
                    int temp = marray[i, j];
                    int col = (marray.GetLength(1) - 1) - j;
                    marray[i, j] = marray[i, col];
                    marray[i, col] = temp;
                }
            }

            //Показываем результат
            for (int i = 0; i < marray.GetLength(0); i++)
            {
                for (int j = 0; j < marray.GetLength(1); j++)
                {
                    Console.Write(marray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
