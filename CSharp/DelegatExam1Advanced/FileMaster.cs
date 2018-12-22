using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using static DelegatExam1Advanced.Notifer;

namespace DelegatExam1Advanced
{
    class FileMaster
    {
        public static FileMaster fileMaster { get; private set; } = new FileMaster();
        public string FileName { get; set; }
        BinaryFormatter binFormer;
        FileStream fStream;
        List<Pilot> listPilots;
        FileMaster()
        {
            binFormer = new BinaryFormatter();
            listPilots = new List<Pilot>();
        }
        void AddPilot(Pilot pilot)
        {
            int index = listPilots.FindIndex(p => p.Name == pilot.Name);
            if(index < 0) listPilots.Add(pilot);
            else
            {
                listPilots[(int)index].AddResultFlights(pilot.Flights.Last().Value);
            }
        }
        public List<Pilot> ReadFromFile()
        {
            try
            {
                using (FileStream fStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    if (fStream.Length != 0)
                    {
                        listPilots = binFormer.Deserialize(fStream) as List<Pilot>;
                        return listPilots;
                    }
                }
            }
            catch (Exception) { Console.WriteLine(notifer[mc.ERR_READ]); Program.Wait(); }
            return null;
        }
        void WriteToFile()
        {
            AddPilot(Airplane.airplane.Pilot);

            try
            {
                using (fStream = new FileStream(FileName, FileMode.Truncate, FileAccess.Write))
                {
                    binFormer.Serialize(fStream, listPilots);
                }
            }
            catch (Exception) { Console.WriteLine(notifer[mc.ERR_WRITE]); Program.Wait(); }
        }
        public Pilot this[int index]
        {
            get { return listPilots.ElementAtOrDefault(index); }
        }
        ~FileMaster()
        {
            WriteToFile();
            if (fStream != null) fStream.Close();
        }
    }
}
