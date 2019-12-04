using System;
using static System.Console;

namespace task3
{
    class Complex
    {
        double a, b;
        const int iSquare = -1;
        public Complex(double a, double b) { this.a = a; this.b = b; }
        public override string ToString()
        {
            return $"{a}{(b>0?"+":"")}{b}i";
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        static public bool operator ==(Complex o1, Complex o2)
        {
            return o1.a == o2.a && o1.b == o2.b;
        }
        static public bool operator !=(Complex o1, Complex o2)
        {
            return !(o1 == o2);
        }
        static public Complex operator +(Complex o1, Complex o2)
        {
            return new Complex(o1.a + o2.a,o1.b + o2.b);
        }
        static public implicit operator Complex (int number)
        {
            return new Complex(number, 0);
        }
        static public Complex operator -(Complex o1, Complex o2)
        {
            return new Complex(o1.a - o2.a, o1.b - o2.b);
        }
        static public Complex operator *(Complex o1, Complex o2)
        {
            double ac = o1.a * o2.a, bc = o1.b * o2.a;
            double ad = o1.a * o2.b, bd = o1.b * o2.b;
            return new Complex(ac - bd, bc + ad);
        }
        static public Complex operator /(Complex o1, Complex o2)
        {
            double ac = o1.a * o2.a, bc = o1.b * o2.a;
            double ad = o1.a * o2.b, bd = o1.b * o2.b;
            double c2d2 = (o2.a * o2.a) + (o2.b * o2.b);

            return new Complex(((ac + bd) / c2d2),((bc - ad) / c2d2));
        }
    }
    class Program
    {
        static void Main()
        {
            Complex first = new Complex(3, -4);
            Complex second = new Complex(-1, 2);
            WriteLine($"({first})+({second})={first + second}");
            WriteLine($"({first})-({second})={first - second}");
            WriteLine($"({first})*({second})={first * second}");
            WriteLine($"({first})/({second})={first / second}");

            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 = {0}", z1);
        }
    }
}
