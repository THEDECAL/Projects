using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsExam
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string appGUID = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();
            bool exists;
            Mutex mutex = new Mutex(true, appGUID, out exists);

            if (exists)
            {
                if (args.Count() == 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    Console.WriteLine("Console Run!");
                }
            }
            else
            {
                MessageBox.Show("Копия приложения уже запущена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }
    }
}
