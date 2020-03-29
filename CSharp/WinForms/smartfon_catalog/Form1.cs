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
        /// <summary>
        /// Текущая страницы (счёт с ноля)
        /// </summary>
        int page = 0;
        /// <summary>
        /// Общее кол-во страниц
        /// </summary>
        int amPages = 0;
        /// <summary>
        /// Список телефонов
        /// </summary>
        List<Smartfone> db = Downloader.GetSmartfones();
        static public ProgressForm PBar { get; private set; } = new ProgressForm();
        public Form1()
        {
            if (db.Count == 0)
            {
                PBar.Show();
                Downloader.DownloadPhones();
                db = Downloader.GetSmartfones();
                PBar.Close();
            }

            InitializeComponent();
            ClientSize = new Size(PhoneBriefly.size.Width * 4 + gbMenu.Size.Width, PhoneBriefly.size.Height * 2);
            gbMenu.Size = new Size(gbMenu.Width, PhoneBriefly.size.Height * 2);
            gbCatalog.Size = new Size(PhoneBriefly.size.Width * 4, PhoneBriefly.size.Height * 2);
            MinimumSize = Size;
            MaximumSize = Size;
            GetValuesToDB();
            LoadData();
        }
        /// <summary>
        /// Метод для отбора телефона в соостветсвии выбранными фильтрами
        /// </summary>
        /// <param name="s">Принимает объект телефона</param>
        /// <returns>Возвращает true, если телефон соответсвует фильтру иначе false</returns>
        bool FilterCheck(Smartfone s)
        {
            bool isValid = true;
            foreach (var prop in s.GetType().GetProperties())
            {
                int i = gbFilters.Controls.IndexOfKey("lb" + prop.Name);
                if(i > -1)
                {
                    ListBox lstBox = gbFilters.Controls[i] as ListBox;

                    if (lstBox.SelectedIndices.Count > 0)
                    {
                        bool check = false;
                        foreach (int index in lstBox.SelectedIndices)
                        {
                            string val = s.GetType().GetProperty(prop.Name).GetValue(s) as string;
                            if (lstBox.Items[index] as string == val)
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
        /// <summary>
        /// Метод загрузки данных на страницу
        /// </summary>
        void LoadData()
        {
            var filter = db.Where(o => FilterCheck(o)).ToList();

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
        /// <summary>
        /// Метод заполнения вариантов для выбора, в фильтре, путём выборки уникальных значений в полях
        /// </summary>
        void GetValuesToDB()
        {
            //Массив названий полей для выборки
            string[] fltr = new string[] { "RAM", "BMEM", "ScrDiag", "MatrixType", "QualityGeneralCamera", "QualityFrontalCamera", "Brand" };

            foreach (var item in fltr)
            {
                var variants = db.GroupBy(o => o.GetType().GetProperty(item).GetValue(o, null)).Select(o => o.Key).ToList();
                var lstBox = gbFilters.Controls[gbFilters.Controls.IndexOfKey("lb" + item)] as ListBox;
                lstBox.DataSource = variants.ToArray();
                lstBox.SelectedIndex = -1;
                lstBox.SelectedIndexChanged += (s, e) => { LoadData(); page = 0; };
            }
        }
        /// <summary>
        /// Метод для выборки следующей страницы
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            page = (page == amPages - 1) ? 0 : page + 1;
            LoadData();
        }
        /// <summary>
        /// Метод для выборки предыдущей страницы
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            page = (page == 0) ? amPages - 1 : page - 1;
            LoadData();
        }
    }
}
