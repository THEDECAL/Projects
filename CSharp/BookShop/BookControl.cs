using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class BookControl : UserControl
    {
        Book book;
        private BookControl()
        {
            InitializeComponent();
        }
        public BookControl(Book book) : this()
        {
            if (book != null)
            {
                this.book = book;
                btnImage.BackgroundImage = Downloader.BytesToImage(book.Image);
                btnImage.BackgroundImageLayout = ImageLayout.Zoom;

                lbName.Text = book.Name;
                lbAuthor.Text = book.Author.Name;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {

        }

        private void btnImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsRightClick.Show(this, e.Location);
            }
        }
    }
}
