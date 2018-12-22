using System;
using static System.Console;

namespace task1_2
{
    struct LinearEquation
    {
        int A, B;
        public LinearEquation(int a, int b) { A = a; B = b; }
        public void Parse(string line)
        {
            char[] delimiters = { ' ', ',' };
            string[] splitLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length != 0)
            {
                A = Convert.ToInt32(splitLine[0]);
                B = Convert.ToInt32(splitLine[1]);
            }
        }
        static public string SystemEq(LinearEquation eq1, LinearEquation eq2)
        {
            //Так как оба уравнения сравниваются с 0, то x и y всегда 0
            return $"x=0,y=0";
        }
        public override string ToString()
        {
            return $"{A}x{(B < 0 ? "" : "+")}{B}y=0";
        }
    }
    class Program
    {
        static void Main()
        {
            LinearEquation EQ = new LinearEquation(12, 13);
            WriteLine(EQ);
            EQ.Parse("30,-15");
            WriteLine(EQ);
            WriteLine();

            LinearEquation EQ1 = new LinearEquation(8, -3);
            LinearEquation EQ2 = new LinearEquation(5, -2);
            WriteLine($"{EQ1}\n{EQ2}\n-----");
            WriteLine(LinearEquation.SystemEq(EQ1,EQ2));
        }
    }
}
