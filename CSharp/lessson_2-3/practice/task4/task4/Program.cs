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

            Console.Write("������� ������: ");
            string line = Console.ReadLine();

            string[] words = line.Split(" .,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //foreach (string i in words) Console.WriteLine(i);
            Console.WriteLine($"���-�� ���� � �������� ������: {words.Length}");

            Console.WriteLine("������� \"Ctrl + C\" ��� ������.");
            Console.ReadKey();
            goto start;
        }
    }
}
