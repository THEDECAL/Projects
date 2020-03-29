using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main()
        {
            string fileName = "Program.cs";
            string newFileName = "new_" + fileName;
            try
            {
                //Копирую файл и изменяю его на ходу
                //File.Copy(fileName,newFileName);
                using (FileStream rStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream wStream = new FileStream(newFileName, (File.Exists(newFileName) ? FileMode.Truncate : FileMode.Create), FileAccess.Write))
                    {
                        byte[] buffer = new byte[rStream.Length];
                        rStream.Read(buffer, 0, buffer.Length);
                        string[] text = Encoding.UTF8.GetString(buffer).Split("\n".ToCharArray());
                        
                        for (int i = 0; i < text.Length; i++)
                        {
                            text[i] = text[i].Replace("public ", "private ");

                            while (text[i].Contains("  "))
                                text[i] = text[i].Replace("  ", " ");

                            char[] charLine = text[i].ToCharArray();
                            Array.Reverse(charLine);
                            text[i] = new string(charLine);
                            wStream.Write(Encoding.UTF8.GetBytes(text[i]), 0 ,text[i].Length);
                            
                            Console.WriteLine(text[i]);
                        }
                    }
                }

                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
