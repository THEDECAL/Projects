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
        //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["geekpc"].ConnectionString;
        static DataContext dc = new DataContext(cs);
        List<Smartfone> db = dc.GetTable<Smartfone>().ToList();
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(PhoneBriefly.size.Width * 4 + gbMenu.Size.Width, PhoneBriefly.size.Height * 2);
            gbMenu.Size = new Size(gbMenu.Width, PhoneBriefly.size.Height * 2);
            gbCatalog.Size = new Size(PhoneBriefly.size.Width * 4, PhoneBriefly.size.Height * 2);
            MinimumSize = Size;
            MaximumSize = Size;
            GetValuesToDB();
            LoadData();
        }
        bool FilterCheck(Smartfone s)
        {
            bool isValid = true;
            foreach (var prop in s.GetType().GetProperties())
            {
                int i = gbFilters.Controls.IndexOfKey("lb" + prop.Name);
                if(i > -1)
                {
                    ListBox lstBox = gbFilters.Controls[i] as ListBox;
                    var val = s.GetType().GetProperty(prop.Name).GetValue(s);
                    ;
                    if (lstBox.SelectedIndices.Count > 0)
                    {
                        bool check = false;
                        foreach (int index in lstBox.SelectedIndices)
                        {
                            ;
                            if (lstBox.Items[index] == "") check = true;
                            else if (lstBox.Items[index] == val)
                            {
                                check = true;
                                break;
                            }
                        }
                        isValid = check;
                        if (!check) break;
                    }
                }
            }
            return isValid;
        }
        void LoadData()
        {
            var filter = db.Where(o => FilterCheck(o)).ToList();
            ;
            UpdatePageNumber(filter);
            var tb = filter.Skip(page * 8).Take(8);
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
        void UpdatePageNumber(List<Smartfone> tb)
        {
            amPages = ((int)Math.Ceiling((double)tb.Count() / 8));
            if (amPages > 0)
                lbPage.Text = $"{page + 1} / {amPages}";
        }
        void GetValuesToDB()
        {
            string[] fltr = new string[] { "RAM", "BMEM", "ScrDiag", "MatrixType", "QualityGeneralCamera", "QualityFrontalCamera", "Brand" };
            var tb = dc.GetTable<Smartfone>().ToList();
            foreach (var item in fltr)
            {
                var variants = tb.GroupBy(o => o.GetType().GetProperty(item).GetValue(o, null)).Select(o => o.Key).ToList();
                var lstBox = gbFilters.Controls[gbFilters.Controls.IndexOfKey("lb" + item)] as ListBox;
                variants.Insert(0, "");
                lstBox.DataSource = variants.ToArray();
                lstBox.SelectedIndexChanged += (s, e) => { LoadData(); page = 0; };
            }
            ;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page = (page == amPages - 1) ? 0 : page + 1;
            LoadData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            page = (page == 0) ? amPages - 1 : page - 1;
            LoadData();
        }
    }
}
