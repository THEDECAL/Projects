using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace smartfon_catalog
{
    static class Downloader
    {
        static public HtmlDocument GetPage(string URL)
        {
            WebClient client = new WebClient();
            HtmlDocument htmlDoc = new HtmlDocument();

            byte[] page = client.DownloadData(URL);
            string htmlPage = Encoding.UTF8.GetString(page);
            htmlDoc.LoadHtml(htmlPage);

            return htmlDoc;
        }
        static public Image GetImage(string URL)
        {
            WebClient client = new WebClient();
            byte[] image = client.DownloadData(URL);
            using (MemoryStream ms = new MemoryStream(image, 0, image.Length))
            {
                return Image.FromStream(ms, true);
            }
        }
    }
}
