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
            double[] x = new double[3]; //Координаты x
            double[] y = new double[3]; //Координаты y
            double[] D = new double[3]; //Растояние между двумя точками

            //Ввод точек
            Console.WriteLine($"Введите координаты трёх точек:");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write($"Введите x, точки №{i + 1}: ");
                x[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Введите y, точки №{i + 1}: ");
                y[i] = Convert.ToInt32(Console.ReadLine());
            }
            //Вычисление D
            D[0] = Math.Sqrt(Math.Pow((x[1] - x[0]), 2) + Math.Pow((y[1] - y[0]), 2));
            D[1] = Math.Sqrt(Math.Pow((x[2] - x[0]), 2) + Math.Pow((y[2] - y[0]), 2));
            D[2] = Math.Sqrt(Math.Pow((x[2] - x[1]), 2) + Math.Pow((y[2] - y[1]), 2));

            //Периметр и полупериметр
            double P = D[0] + D[1] + D[2];
            double p = P / 2;
            Console.WriteLine($"Периметр треугольника: {P}");
            Console.WriteLine($"Площадь треугольника: {(p * (p - D[0]) * (p - D[1]) * (p - D[2])) * 0.5}");
        }
    }
}
