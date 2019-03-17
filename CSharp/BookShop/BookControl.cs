using System;
using System.Windows.Forms;

namespace BookShop
{
    public partial class BookControl : UserControl
    {
        public Book Book { get; set; }
        public BookControl()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
        }
        public BookControl(Book book) : this()
        {
            Init(book);
        }
        public void Init(Book book)
        {
            if (book != null)
            {
                Book = book;
                if (book.Image != null)
                {
                    pbImage.BackgroundImage = Downloader.BytesToImage(book.Image);
                    pbImage.BackgroundImageLayout = ImageLayout.Zoom;
                }

                tbName.Text = book.Name;
                tbPrice.Text = book.Price.ToString() + " грн.";
            }
        }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Form1.CurrentUser.UserType.Name == "Admin")
            {
                BookControlDesc bcd = new BookControlDesc(Parent.Parent as Form1, Book, BookControlDesc.Mode.EDIT);
                bcd.ShowDialog();
            }
            else Form1.Msg(Form1.MsgType.ERR_PERM, MessageBoxIcon.Warning);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.CurrentUser.UserType.Name == "Admin")
            {
                Book.Deleted = true;
                SQLDbConntext.DbContext.SaveChanges();
                Form1 genericForm = Parent.Parent as Form1;
                genericForm.LoadBooks();
            }
            else Form1.Msg(Form1.MsgType.ERR_PERM, MessageBoxIcon.Warning);
        }

        private void положитьВКорзинуToolStripMenuItem_Click(object sender, EventArgs e) => Form1.ListBooks.Add(Book);

        private void pbImage_MouseMove(object sender, MouseEventArgs e) => pbImage.BackColor = System.Drawing.Color.Red;

        private void pbImage_MouseLeave(object sender, EventArgs e) => pbImage.BackColor = System.Drawing.Color.White;

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsRightClick.Show(this, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                BookControlDesc bcd = new BookControlDesc(Parent.Parent as Form1, Book, BookControlDesc.Mode.SHOW);
                bcd.ShowDialog();
            }
        }
    }
}
