using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Point2D<T>
    {
        public T x { get; set; }
        public T y { get; set; }
        public Point2D()
        {
            x = default(T);
            y = default(T);
        }
        public Point2D(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"x:{x},y:{y}";
        }
    }
    class Line<T>
    {
        Point2D<T> firstP;
        Point2D<T> secondP;
        public Line()
        {
            firstP = new Point2D<T>(default(T), default(T));
            secondP = new Point2D<T>(default(T), default(T));
        }
        public Line(Point2D<T> firstP, Point2D<T> secondP)
        {
            this.firstP = firstP;
            this.secondP = secondP;
        }
        public Line(T firstX, T firstY, T secondX, T secondY)
        {
            firstP = new Point2D<T>(firstX, firstY);
            secondP = new Point2D<T>(secondX, secondY);
        }
        public override string ToString()
        {
            return $"First point: {firstP}\nSecond point: {secondP}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Line<double> p1 = new Line<double>(3.5, 2.8, 7.5, 9.9);
            Console.WriteLine(p1);
            Line<int> p2 = new Line<int>(new Point2D<int>( 3, 2 ), new Point2D<int>( 7, 9 ));
            Console.WriteLine(p2);
            Console.ReadKey();
        }
    }
}
