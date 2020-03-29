using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
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
    }
    class Point3D : Point2D<int>
    {
        public int z { get; set; }
        public Point3D()
        {
            z = default(int);
        }
        public Point3D(int x, int y, int z) : base(x,y)
        {
            this.z = z;
        }
        public override string ToString()
        {
            return $"x:{x}, y:{y}, z:{z}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p = new Point3D(12,5,9);
            Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
