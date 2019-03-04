using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartfon_catalog
{
    public partial class Form1 : Form
    {
        int page = 0;
        int amPages = 0;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["geekpc"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(PhoneBriefly.size.Width * 4 + gbMenu.Size.Width, PhoneBriefly.size.Height * 2);
            gbMenu.Size = new Size(gbMenu.Width, PhoneBriefly.size.Height * 2);
            gbCatalog.Size = new Size(PhoneBriefly.size.Width * 4, PhoneBriefly.size.Height * 2);
            MinimumSize = Size;
            MaximumSize = Size;
            GetAmountRowsToDB();
            LoadData();
        }
        void LoadData()
        {
            DataContext dc = new DataContext(cs);
            var tb = dc.GetTable<Smartfone>().Skip(page * 8).Take(8);

            gbCatalog.Controls.Clear();
            int cnt = 0, x = 0, y = 0;
            foreach (var item in tb)
            {
                Smartfone s = item as Smartfone;
                PhoneBriefly pb = new PhoneBriefly(s);
                pb.Location = new Point(x, y);
                gbCatalog.Controls.Add(pb);

                x += pb.Width;
                if (cnt == 3) { y += pb.Height; x = 0; }
                cnt++;
            }
        }
        void UpdatePagePanel() => lbPage.Text = $"{page + 1} / {amPages}";
        void GetAmountRowsToDB()
        {
            DataContext dc = new DataContext(cs);
            amPages = dc.GetTable<Smartfone>().Count() / 8;
            if (amPages > 0) UpdatePagePanel();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page = (page == amPages - 1) ? 0 : page + 1;
            LoadData();
            UpdatePagePanel();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            page = (page == 0) ? amPages - 1 : page - 1;
            LoadData();
            UpdatePagePanel();
        }
    }
}
