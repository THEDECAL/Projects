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
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }
        public void SetMaximum(int max) => pbDownloads.Maximum = max;
        public void SetProgress(int val) => pbDownloads.Value = val;
    }
}
