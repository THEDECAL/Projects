using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartfon_catalog
{
    partial class PhoneInfo : Form
    {
        private PhoneInfo()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
        }
        public PhoneInfo(Smartfone smartfone) : this()
        {
            pbImage.BackgroundImage = Downloader.BytesToImage(smartfone.Image);
            pbImage.BackgroundImageLayout = ImageLayout.Zoom;
            lbName.Text = smartfone.Brand + '\n' + smartfone.Name;

            Type t = typeof(Smartfone);
            foreach (var item in t.GetProperties())
            {
                if (item.PropertyType.Name == "String")
                {
                    if (item.Name != "Brand" && item.Name != "Name")
                    {
                        var tmp = gbDesc.Controls.Find("lb" + item.Name, true).First();
                        ;
                    }
                }
            }
        }
    }
}
