using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Threading.Thread;

namespace smartfon_catalog
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
            for (int i = 1; i <= 1; i++)
            {
                Sleep(1500);
                HtmlNode page = Downloader.GetPage(siteRef + $";page={i}").DocumentNode;
                string xpath = "//*[@id='catalog_goods_block']/div/div[@class='g-i-tile g-i-tile-catalog']/div[1]/div[1]/div[1]/div[@class='g-i-tile-i-box-desc']";
                var phoneNodes = root.SelectNodes(xpath).ToList();
                ;
                foreach (var item in phoneNodes)
                {
                    Smartfone phone = new Smartfone();
                    var imageNode = item.SelectNodes("div[1]/div[1]/a").First();
                    string imgRef = imageNode.Element("img").Attributes[0].Value;
                    string phoneRef = imageNode.Attributes[0].Value + "#tab=characteristics";
                    phone.Image = Downloader.GetImage(imgRef);
                    phone.Name = item.ChildNodes[5].ChildNodes[1].InnerHtml.Replace("\n", "");

                    Sleep(1500);
                    HtmlNode phonePage = Downloader.GetPage(phoneRef).DocumentNode;
                    ;
                }
            }
            ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
