using System;
using System.Text;
using static System.Console;

namespace task4
{
    class Fraction
    {
        int integer, numerator, denomerator;
        public Fraction(int integer)
        {
            this.integer = integer;
        }
        public Fraction(int numerator, int denomerator)
        {
            this.numerator = numerator;
            this.denomerator = denomerator;
        }
        public Fraction(int integer, int numerator, int denomerator):this(numerator,denomerator)
        {
            this.integer = integer;
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            if (integer > 0) text.Append(integer);
            if (numerator > 0 && denomerator > 0) text.Append($"[{numerator}/{denomerator}]");

            return text.ToString();
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        static public implicit operator Fraction(int number)
        {
            return new Fraction(number);
        }
        static public Fraction operator +(Fraction o1, Fraction o2)
        {
            CommonDenomerator(ref o1, ref o2);
            Fraction temp = new Fraction(o1.integer + o2.integer, o1.numerator + o2.numerator, o1.denomerator);
            temp.Reduction();
            return temp;
        }
        static public Fraction operator -(Fraction o1, Fraction o2)
        {
            CommonDenomerator(ref o1, ref o2);
            if (o1.integer != 0 && o2.integer != 0)
            {
                o1 = new Fraction(o1.integer,1) + new Fraction(o1.numerator, o1.denomerator);
                o2 = new Fraction(o2.integer,1) + new Fraction(o2.numerator, o2.denomerator);
            }
            Fraction temp = new Fraction(o1.integer - o2.integer, o1.numerator - o2.numerator, o1.denomerator);
            temp.Reduction();
            return temp;
        }
        public void IntegerToFraction() //Функция приведения целого числа к дроби (например 9 будет 9/1)
        {
            if (integer != 0 && numerator == 0 || denomerator == 0)
            {
                numerator = integer;
                integer = 0;
                denomerator = 1;
            }
        }
        public void Reduction() //Функция сокращения дроби
        {
            if (numerator > denomerator)
            {
                decimal temp = (decimal)numerator / (decimal)denomerator;
                if (temp == Math.Truncate(temp))
                {
                    integer += (int)temp;
                    numerator = 0;
                    denomerator = 0;
                }
            }
        }
        static public void CommonDenomerator(ref Fraction o1, ref Fraction o2) //Функция приведения дробей к общему знаменателю
        {
            for (int i = (o1.denomerator>o2.denomerator?o1.denomerator:o2.denomerator);; i+=i)
            {
                if (i % o1.denomerator == i % o2.denomerator)
                {
                    o1.numerator *= i / o1.denomerator;
                    o2.numerator *= i / o2.denomerator;
                    o1.denomerator = o2.denomerator = i;
                    break;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            //Fraction first = new Fraction(5,12,3);
            Fraction first = new Fraction(4, 1, 2);
            Fraction second = new Fraction(5 ,1, 3);

            WriteLine($"{first}+{second}={first + second}");
            WriteLine($"{first}-{second}={first - second}");
            WriteLine($"4+{second}={4 + second}");
        }
    }
}
