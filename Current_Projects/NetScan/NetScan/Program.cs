using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace NetScan
{
    class Program
    {
        static CommandHelper commandHelper = new CommandHelper();
        static void Main(string[] args)
        {
            try
            {
                CommandHelper.Run(args);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.ReadKey();
        }
    }
}
