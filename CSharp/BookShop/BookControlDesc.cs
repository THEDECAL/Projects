using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    partial class BookControlDesc : Form
    {
        Book book;
        public enum Mode { ADD, EDIT, SHOW };
        Mode currentMode;
        Form1 parent;
        private BookControlDesc()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
        }
        public BookControlDesc(Form1 parent, Book book, Mode mode) : this()
        {
            this.parent = parent;
            this.book = book;
            currentMode = mode;
            Text = book.Name;

            if (mode > Mode.ADD && book != null)
            {
                tbName.Text = book.Name;
                tbAuthor.Text = book.Author.Name;
                tbPages.Text = book.Pages.ToString();
                tbPrice.Text = book.Price.ToString() + (mode == Mode.EDIT ? "" : " грн.");
                tbPublisher.Text = book.Publisher.Name;
                tbYear.Text = book.Year.ToString();
                tbGenre.Text = book.Genre.Name;
                if (book.Image != null)
                {
                    pbImage.BackgroundImage = Downloader.BytesToImage(book.Image);
                    pbImage.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }

            if (mode < Mode.SHOW)
            {
                TextBoxesEnableDisable(true);

                pbImage.Click += (o, e) =>
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (DialogResult.OK == ofd.ShowDialog())
                    {
                        pbImage.BackgroundImage = Image.FromFile(ofd.FileName);
                        pbImage.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                };
            }
        }
        private void TextBoxesEnableDisable(bool mode)
        {
            tbName.Enabled = mode;
            tbAuthor.Enabled = mode;
            tbPages.Enabled = mode;
            tbPrice.Enabled = mode;
            tbPublisher.Enabled = mode;
            tbYear.Enabled = mode;
            tbGenre.Enabled = mode;
        }

        private void BookControlDesc_FormClosing(object sender, FormClosingEventArgs e)
        {
            book.Name = tbName.Text;
            book.Author = SQLDbConntext.CheckUniqAuthor(tbAuthor.Text);
            book.Genre = SQLDbConntext.CheckUniqGenre(tbGenre.Text);
            book.Publisher = SQLDbConntext.CheckUniqPublisher(tbPublisher.Text);
            try { book.Year = Convert.ToInt32(tbYear.Text); } catch (Exception) { }
            try { book.Pages = Convert.ToInt32(tbPages.Text); } catch (Exception) { }
            try { book.Price = Convert.ToDouble(tbPrice.Text.Replace(".", ",").Replace(" грн.","")); } catch (Exception) { }
            try { book.CostPrice = book.GetCostPrice(); } catch (Exception) { }
            try { book.Image = Downloader.ImageToBytes(pbImage.BackgroundImage); } catch (Exception) { }

            if (currentMode == Mode.ADD) SQLDbConntext.DbContext.Books.Add(book);

            SQLDbConntext.DbContext.SaveChanges();
            if(parent != null) parent.LoadBooks();
        }
    }
}
