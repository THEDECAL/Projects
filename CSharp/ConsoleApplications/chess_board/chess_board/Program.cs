using System;

namespace chess_board
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 8;

            bool shift = false;
            //Высота
            for (int i = 0; i < size; i++)
            {
                //Ширина
                for (int j = 0; j < size; j++)
                {
                    int _shift = Convert.ToInt32(shift);
                    string symbols = ((j + _shift) % 2 > 0) ? "o " : "  ";
                    Console.Write(symbols);
                }
                Console.WriteLine();
                
                shift = !shift;
            }
            Console.ReadKey();
        }
    }
}
