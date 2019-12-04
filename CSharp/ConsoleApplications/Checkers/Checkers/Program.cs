using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main()
        {
            Board board = new Board();
            Console.WriteLine(board);
            ;
            //board.Navigate();
            Console.ReadKey();
        }
    }
}
