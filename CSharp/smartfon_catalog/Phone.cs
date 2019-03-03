using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartfon_catalog
{
    partial class Phone : UserControl
    {
        public Smartfone Smartfone { get; set; }
        public Phone()
        {
            InitializeComponent();
            DataInit();
        }
        void DataInit()
        {
            if (Smartfone != null)
            {

            }
        }
    }
}
