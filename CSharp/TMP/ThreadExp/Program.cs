using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(RunEndlessCycle);
            Task.Run(RunEndlessCycle);
            Task.Run(RunEndlessCycle);

            Console.ReadKey();
        }
        static void RunEndlessCycle()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine(++i);
            }
        }
    }
}
