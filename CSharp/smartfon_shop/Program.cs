using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Threading.Thread;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartfon_shop
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string siteRef = "https://rozetka.com.ua/mobile-phones/c80003/preset=smartfon;seller=rozetka;view=tile";
            HtmlNode root = Downloader.GetPage(siteRef).DocumentNode;
            int pageCount = Convert.ToInt32(root.SelectNodes("//*[@id='navigation_block']/ul/*").Where(o => o.Name == "li").Last().Id.Replace("page", ""));
            //for (int i = 1; i <= pageCount; i++)
            //{

                //List<string> phoneRefs = new List<string>();
                Sleep(1500);
                //HtmlNode page = Downloader.GetPage(link + $";page={i}").DocumentNode;
                HtmlNode phonesPage = Downloader.GetPage(siteRef + $";page=1").DocumentNode;
                //var phoneNodes = root.SelectNodes("//*[@id='catalog_goods_block']/div/div").Where(o => o.Attributes[0].Value == ("g-i-tile g-i-tile-catalog")).ToList();
                string xpath = "//*[@id='catalog_goods_block']/div/div[@class='g-i-tile g-i-tile-catalog']/div[1]/div[1]/div[1]/div[@class='g-i-tile-i-box-desc']";
                var phoneNodes = root.SelectNodes(xpath).ToList();
                ;
                foreach (var item in phoneNodes)
                {
                    Smartfone tmp = new Smartfone();
                    //string imageRef = 
                    //string href = item.ChildNodes[3].ChildNodes[1].Element("a").Attributes[1].Value;
                    //Sleep(1500);
                    //HtmlNode phonePageAll = Downloader.GetPage(href).DocumentNode;
                    //Sleep(1500);
                    //HtmlNode phonePageChrct = Downloader.GetPage(href + "#tab=characteristics").DocumentNode;
                    //phoneRefs.Add(href);
                }
            //}
            ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
