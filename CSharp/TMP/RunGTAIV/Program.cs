using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace RunGTAIV
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToRock = @"C:\Program Files (x86)\Rockstar Games Social Club\RGSCLauncher.exe";
            string pathToGTAIV = @"D:\Grand Theft Auto IV\LaunchGTAIV.exe";
            var arrayProc = new string[]{ pathToRock, pathToGTAIV };

            foreach (var item in arrayProc)
            {
                var ss = new SecureString();
                var password = "222r00ki".ToCharArray().ToList();
                password.ForEach((c) => ss.AppendChar(c));
                Directory.SetCurrentDirectory(Path.GetDirectoryName(item));
                Process.Start(item, "the-decal", ss, AppDomain.CurrentDomain.ToString());
            }

            return;
        }
    }
}
