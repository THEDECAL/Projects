using System;
using System.Text;
using static System.Console;

//Класс для работы с дробями
//
//
//Не всегда до конца округляет дробь
namespace task4
{
    class Fraction
    {
        int integer;
        int numerator;
        int denomerator;
        public Fraction(int integer)
        {
            this.integer = integer;
        }
        public Fraction(int numerator, int denomerator)
        {
            this.numerator = numerator;
            this.denomerator = Math.Abs(denomerator);
        }
        public Fraction(int integer, int numerator, int denomerator) : this(numerator, denomerator)
        {
            this.integer = integer;
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            if (integer != 0) text.Append(integer);
            if (numerator > 0 || denomerator > 0) text.Append($"[{numerator}/{denomerator}]");

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
        public static implicit operator Fraction (int number)
        {
            return new Fraction(number, 1);
        }
        public static implicit operator Fraction(double number)
        {
            int @int = (int)Math.Truncate(number);
            return new Fraction(@int, (int)number%@int, (int)number);
        }
        static public bool operator true(Fraction o1)
        {
            return (o1.numerator > o1.denomerator) ? true : false;
        }
        static public bool operator false(Fraction o1)
        {
            return (o1.numerator < o1.denomerator) ? true : false;
        }
        static public bool operator >(Fraction o1, Fraction o2)
        {
            Fraction temp1 = Transformation(o1), temp2 = Transformation(o2);
            CommonDenomerator(temp1, temp2);
            return temp1.numerator > temp2.numerator;
        }
        static public bool operator <(Fraction o1, Fraction o2)
        {
            return !(o1 > o2);
        }
        static public Fraction operator +(Fraction o1, Fraction o2)
        {
            Fraction[] a = { (Fraction)o1.MemberwiseClone(), (Fraction)o2.MemberwiseClone() };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].integer != 0)
                {
                    a[i] = Transformation(a[i]);
                }
            }
            CommonDenomerator(a[0], a[1]);
            return new Fraction(a[0].numerator + a[1].numerator, a[0].denomerator).Reduction();
        }
        static public Fraction operator -(Fraction o1, Fraction o2)
        {
            Fraction[] a = { (Fraction)o1.MemberwiseClone(), (Fraction)o2.MemberwiseClone() };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].integer != 0)
                {
                    a[i] = Transformation(a[i]);
                }
            }
            CommonDenomerator(a[0],a[1]);
            return new Fraction(a[0].numerator - a[1].numerator, a[0].denomerator).Reduction();
        }
        static public Fraction operator *(Fraction o1, Fraction o2)
        {
            Fraction[] a = { (Fraction)o1.MemberwiseClone(), (Fraction)o2.MemberwiseClone() };
            if (o1.integer < 0 && o2.integer < 0)
            {
                a[0].integer=Math.Abs(o1.integer);
                a[1].integer=Math.Abs(o2.integer);
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].integer != 0)
                {
                    a[i] = Transformation(a[i]);
                }
            }
            return new Fraction(a[0].numerator * a[1].numerator, a[0].denomerator * a[1].denomerator).Reduction();
        }
        static public Fraction operator /(Fraction o1, Fraction o2)
        {
            Fraction[] a = { (Fraction)o1.MemberwiseClone(), (Fraction)o2.MemberwiseClone() };
            if (o1.integer < 0 && o2.integer < 0)
            {
                a[0].integer = Math.Abs(o1.integer);
                a[1].integer = Math.Abs(o2.integer);
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].integer != 0)
                {
                    a[i] = Transformation(a[i]);
                }
            }
            if (a[1].numerator < 0) //Раскрытие скобок
            {
                a[1].numerator = Math.Abs(a[1].numerator);
                a[0].numerator = -a[0].numerator;
            }
            if (a[0].denomerator == 0 || a[1].denomerator == 0 || a[1].numerator == 0) return null; //Проверка деления на ноль
            return a[0] * new Fraction(a[1].denomerator,a[1].numerator);
        }
        public Fraction Reduction() //Cокращения дроби
        {
            if (Math.Abs(numerator) > denomerator)
            {
                double @int = (double)numerator / (double)denomerator;
                integer += (int)@int;
                if (@int == Math.Truncate(@int)) { numerator = denomerator = 0; }
                else { numerator %= denomerator; }
            }
            if (numerator < 0 && integer != 0) //Если есть целое число и числитель отрицательный, то переместить минус на целое число
            {
                integer = (integer < 0) ? integer : -integer;
                numerator = Math.Abs(numerator);
            }
            return this;
        }
        static public Fraction Transformation(Fraction o1) //Преобразование смешанного числа в неправильную дробь
        {

            if (o1.integer != 0 && o1.numerator == 0 || o1.denomerator == 0) //Если нет дробной части
            {
                return new Fraction(o1.integer,1);
            }
            else if (o1.integer != 0) //Если смешанное число
            {
                if (o1.integer > 0) return new Fraction(Math.Abs(o1.integer) * o1.denomerator + o1.numerator, o1.denomerator);
                else return new Fraction(-(Math.Abs(o1.integer) * o1.denomerator + o1.numerator), o1.denomerator);
            }
            return (Fraction)o1.MemberwiseClone(); //Если число дробное (без целой части)
        }
        static public void CommonDenomerator(Fraction o1, Fraction o2) //Функция приведения дробей к общему знаменателю
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
            Fraction first = new Fraction(-5, 1, 2);
            Fraction second = new Fraction(2, 3);
            
            WriteLine($"{first} + {second}: {first + second}");
            WriteLine($"{second} + {first}: {second + first}\n");

            WriteLine($"{first} - {second}: {first - second}");
            WriteLine($"{second} - {first}: {second - first}\n");

            WriteLine($"{first} * {second}: {first * second}");
            WriteLine($"{second} * {first}: {second * first}\n");

            WriteLine($"{first} / {second}: {first / second}");
            WriteLine($"{second} / {first}: {second / first}\n");

            WriteLine($"{first} > {second}: {first > second}");
            WriteLine($"{first} < {second}: {first < second}");
            WriteLine($"{second} > {first}: {second > first}");
            WriteLine($"{second} < {first}: {second < first}");

            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;
        }
    }
}
