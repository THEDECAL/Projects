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
                lbBrand.Text = smartfone.Brand.ToString();
                lbName.Text = smartfone.Name;
                if (smartfone.Image != null)
                {
                    Image image = Downloader.BytesToImage(smartfone.Image);
                    btPhoneInfo.BackgroundImage = image;
                }
                btPhoneInfo.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
        /// <summary>
        /// Метод загрузки иозображения для нового телефона
        /// </summary>
        private void btPhoneInfo_Click(object sender, EventArgs e)
        {
            PhoneInfo pi = new PhoneInfo(phone);
            pi.Show();
        }

        private void btPhoneInfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsRightClick.Show(this, e.Location);
        }
        /// <summary>
        /// Метод редактирования телефона
        /// </summary>
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhoneInfo pi = new PhoneInfo(phone, PhoneInfo.Mode.Edit);
            pi.ShowDialog();
        }
        /// <summary>
        /// Метод удаления телефона
        /// </summary>
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLDbContext.DbContext.Smartfones.Remove(phone);
            SQLDbContext.DbContext.SaveChanges();

            var GeneralForm = this.Parent.Parent as Form1;
            GeneralForm.UpdateDb();
            GeneralForm.LoadData();
        }
    }
}
