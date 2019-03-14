using System;
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
                lbPrice.Text = book.Price.ToString() + "грн.";
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

        private void btnImage_MouseMove(object sender, MouseEventArgs e) => btnImage.FlatStyle = FlatStyle.Popup;

        private void btnImage_MouseLeave(object sender, EventArgs e) => btnImage.FlatStyle = FlatStyle.Standard;
    }
}
