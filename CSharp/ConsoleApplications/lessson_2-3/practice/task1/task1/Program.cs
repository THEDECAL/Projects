using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main()
        {
            start:
            Console.Clear();
			
            Random randomNum = new Random();
            int rmin = 1;
            int rmax = 3;

            //Ввод одномерного массива
            double[] A = new double[5];
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Введите дробное число №{i + 1} массива A: ");
                A[i] = Convert.ToDouble(Console.ReadLine());
                //A[i] = Math.Round(randomNum.NextDouble() + randomNum.Next(rmin, rmax), 1);
            }

            Console.WriteLine("Элементы массива A:");
            foreach (double i in A) Console.Write($"{i}\t");
            Console.WriteLine("\n");


            //Генерация многомерного массива
            double[,] B = new double[3, 4];

            Console.WriteLine("Элементы массива B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = Math.Round(randomNum.NextDouble() + randomNum.Next(rmin, rmax), 1);
                    Console.Write($"{B[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Вычисления
            double max = rmin - 0.1;
            double min = rmax + 1;
            double sum = 0;
            double mult = 1;
            double sumEven = 0;
            double sumOdd = 0;

            for (int j = 0; j < B.GetLength(0); j++)
            {
                for (int k = 0; k < B.GetLength(1); k++)
                {
                    for (int i = 0; i < A.Length; i++)
                    {
                        //Поиск общего
                        if ((A[i] == B[j, k]))
                        {
                            //Поиск максимального
                            if (A[i] > max) max = A[i];
                            //Поиск минимального
                            if (A[i] < min) min = A[i];
                        }
                        if (j == 0 && k == 0) //Чтобы запустить один раз
                        {
                            //Поиск чётного числа массива A и суммирование
                            if ((int)A[i] % 2 == 0) sumEven += A[i];
                            //Сумма всех чисел массива A
                            sum += A[i];
                            //Произведение всех чисел массива A 
                            mult *= A[i];
                        }
                    }
                    //Поиск нечётного столбца массива B и суммирование
                    if (k % 2 == 0) sumOdd += B[j,k];
                    //Сумма всех чисел массива B
                    sum += B[j,k];
                    //Произведение всех чисел массива B
                    mult *= B[j,k];
                }
            }
            if (max == rmin - 0.1 || min == rmax + 1) Console.WriteLine($"Общего числа нет.");
            else
            {
                Console.WriteLine($"Максимальное общее число двух массивов: {max}");
                Console.WriteLine($"Минимальное общее число двух массивов: {min}");
            }
            Console.WriteLine($"Сумма всех элементов: {sum}");
            Console.WriteLine($"Произведение всех элементов: {mult}");
            Console.WriteLine($"Сумма чётных элементов массива A: {sumEven}");
            Console.WriteLine($"Сумма нечётных столбцов массива B: {sumOdd}");

			Console.WriteLine("Нажмите \"Ctrl + C\" для выхода.");
            Console.ReadKey();
            goto start;
        }
    }
}
