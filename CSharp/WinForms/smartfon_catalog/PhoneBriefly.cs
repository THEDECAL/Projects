using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace smartfon_catalog
{
    internal partial class PhoneBriefly : UserControl
    {
        static public Size size { get; private set; } = new Size(184, 258);
        Smartfone phone;
        private PhoneBriefly()
        {
            InitializeComponent();
            Size = size;
        }
        public PhoneBriefly(Smartfone smartfone) : this()
        {
            if (smartfone != null)
            {
                phone = smartfone;
                lbBrand.Text = smartfone.Brand;
                lbName.Text = smartfone.Name;
                Image image = Downloader.BytesToImage(smartfone.Image);
                btPhoneInfo.BackgroundImage = image;
                btPhoneInfo.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void btPhoneInfo_Click(object sender, EventArgs e)
        {
            PhoneInfo pi = new PhoneInfo(phone);
            pi.Show();
        }
    }
}
