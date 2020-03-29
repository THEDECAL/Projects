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
        Smartfone phone;
        Mode currMode = Mode.Show;
        public enum Mode { Show, Edit, Add };
        private PhoneInfo()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
        }
        public PhoneInfo(Smartfone smartfone, Mode mode = Mode.Show) : this()
        {
            phone = smartfone;
            currMode = mode;
            if(smartfone.Image != null)
                pbImage.BackgroundImage = Downloader.BytesToImage(smartfone.Image);

            if (mode == Mode.Add)
                pbImage.Click += pbImage_Click;

            pbImage.BackgroundImageLayout = ImageLayout.Zoom;
            Text = smartfone.Brand.ToString() + ' ' + smartfone.Name;

            Type t = typeof(Smartfone);
            foreach (var item in t.GetProperties())
            {
                string val = item.GetValue(smartfone)?.ToString();
                int index = gbDesc.Controls.IndexOfKey("tb" + item.Name);

                if (index > -1)
                {
                    if(mode != Mode.Add) gbDesc.Controls[index].Text = val;
                    if (mode > 0) (gbDesc.Controls[index] as TextBox).ReadOnly = false;
                }
            }
        }
        void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(ofd.FileName);
            }
        }
        void SaveChanged()
        {
            if (pbImage.Image != null)
                phone.Image = Downloader.ImageToBytes(pbImage.Image);

            Type t = typeof(Smartfone);
            foreach (var item in t.GetProperties())
            {
                int index = gbDesc.Controls.IndexOfKey("tb" + item.Name);

                if (item.Name == "Brand")
                    phone.Brand.Name = gbDesc.Controls[index].Text;
                else if (index > -1)
                    t.GetProperty(item.Name).SetValue(phone, gbDesc.Controls[index].Text);
            }
        }

        private void PhoneInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currMode > 0)
            {
                SaveChanged();
                if (currMode == Mode.Add && phone.Brand.Name != "")
                {
                    phone.Brand = Downloader.AddBrand(phone.Brand.Name);
                    SQLDbContext.DbContext.Smartfones.Add(phone);
                }

                SQLDbContext.DbContext.SaveChanges();
            }
        }
    }
}
