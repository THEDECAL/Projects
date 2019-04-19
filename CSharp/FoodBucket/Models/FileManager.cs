using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodBucket.Models
{
    class FileManager
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Recipe>));
        readonly static string pathToFileRecipes = "recipes.xml";
        public static ObservableCollection<Recipe> LoadRecipes()
        {
            try
            {
                if (File.Exists(pathToFileRecipes))
                {
                    using (FileStream fs = new FileStream(pathToFileRecipes, FileMode.Open, FileAccess.Read))
                    {
                        return serializer.Deserialize(fs) as ObservableCollection<Recipe>;
                    }
                }
            }
            catch (Exception) { }
            return new ObservableCollection<Recipe>();
        }
        public static void SaveRecipes(ObservableCollection<Recipe> list)
        {
            try
            {
                //Делаем резервную копию старого файла
                //if (File.Exists(pathToFileRecipes)) File.Move(pathToFileRecipes, $"./{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")}_{pathToFileRecipes}");

                using (FileStream fs = new FileStream(pathToFileRecipes, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(fs, list);
                }
            }
            catch (Exception){ }
        }
    }
}
