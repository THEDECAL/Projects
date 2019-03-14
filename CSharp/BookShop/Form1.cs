using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Form1 : Form
    {
        int BooksOnPage = 16;
        int CurrentPage = 0;
        int amBooks;
        int CountPages;
        User currentUser = User.GetGuest();
        public Form1()
        {
            InitializeComponent();
            tslbLogin.Text = currentUser.Name;
            UpdateCountSelectBooks();
            UpdateCountPages();
            UpdateTextNumberPage();
            LoadBooks();
        }
        private void UpdateCountPages() => CountPages = (int)Math.Ceiling((double)amBooks / BooksOnPage);
        private void UpdateCountSelectBooks() => tslbOnDisplay.Text = (amBooks = SQLDbConntext.DbContext.Books.Count()).ToString();
        private void UpdateTextNumberPage() => tslbPageNumber.Text = $"{CurrentPage + 1}/{CountPages}";
        private void UpdateUserNameText() => tslbLogin.Text = currentUser.Name;
        public bool CheckAccount(string login, string password)
        {
            Account a = SQLDbConntext.DbContext.Accounts.Include(ac => ac.User).FirstOrDefault(b => b.Login == login && b.Password == password);
            if (a != null)
            {
                currentUser = a.User;
                return true;
            }
            else return false;
        }
        private void LoadBooks()
        {
            var listBooks = SQLDbConntext.DbContext.Books.Include(b => b.Author).Include(b => b.Genre).OrderBy(o => o.Id).Skip(CurrentPage * BooksOnPage).Take(BooksOnPage);
            ;
            flpBooks.Controls.Clear();
            int i = 0, x = 0, y = 0;
            foreach (var item in listBooks)
            {
                BookControl bc = new BookControl(item);
                ;
                bc.Location = new Point(x, y);
                flpBooks.Controls.Add(bc);

                if (i == 3) y += bc.Height;
                x += bc.Width;

                i++;
            }
        }

        private void tsbtnPrev_Click(object sender, EventArgs e)
        {
            CurrentPage = (CurrentPage == 0) ? CountPages - 1 : CurrentPage - 1;
            LoadBooks();
            UpdateTextNumberPage();
        }

        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            CurrentPage = (CurrentPage == CountPages - 1) ? 0 : CurrentPage + 1;
            LoadBooks();
            UpdateTextNumberPage();
        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnLogInLogOut_Click(object sender, EventArgs e)
        {
            if (tsbtnLogInLogOut.Text == "Выход")
            {
                currentUser = User.GetGuest();
                tsbtnLogInLogOut.Text = "Вход";
            }
            else
            {
                LogInOutForm liof = new LogInOutForm(this);
                liof.ShowDialog();
                tsbtnLogInLogOut.Text = "Выход";
            }
            UpdateUserNameText();
        }
    }
}
