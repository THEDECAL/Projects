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
    partial class Form1 : Form
    {
        public enum MsgType { ERR_PERM, ERR_LOGIN, ERR_UNIQ_LOGIN, ERR_PASSWORD, ERR_ENTER};
        static string[] Messages = new string[]
        {
            "Недостаток прав на подобные операции",
            "Неверный логин или пароль",
            "Такой логин уже есть или не все поля заполнены",
            "Пароли не совпадают",
            "Войдите в систему"
        };
        int BooksOnPage = 16;
        int CurrentPage = 0;
        int amBooks;
        int CountPages;
        bool isSearch = false;
        public static List<Book> ListBooks { get; private set; } = new List<Book>();
        public static CartForm Cart { get; private set; } = new CartForm();
        public static User CurrentUser { get; set; } = User.GetGuest();
        public Form1()
        {
            InitializeComponent();
            tslbLogin.Text = CurrentUser.Name;
            UpdateCountSelectBooks();
            UpdateCountPages();
            UpdateTextNumberPage();
            UpdateUserNameText();
            LoadBooks();
            InitListBoxSearchTypes();
        }
        private void InitListBoxSearchTypes()
        {
            var lstTypes = new List<string>();
            lstTypes.Add("Название");
            lstTypes.Add("Автор");
            lstTypes.Add("Жанр");
            lstTypes.Add("Издательство");
            tscbSearchType.Items.AddRange(lstTypes.ToArray());
            tscbSearchType.SelectedIndex = 0;
        }
        private void UpdateCountPages() => CountPages = (int)Math.Ceiling((double)amBooks / BooksOnPage);
        private void UpdateCountSelectBooks() => tslbOnDisplay.Text = (amBooks = SQLDbConntext.DbContext.Books.Count()).ToString();
        private void UpdateTextNumberPage() => tslbPageNumber.Text = $"{CurrentPage + 1}/{CountPages}";
        private void UpdateUserNameText() => tslbLogin.Text = CurrentUser.Name;
        public bool CheckAccount(string login, string password)
        {
            Account a = SQLDbConntext.DbContext.Accounts.Include(ac => ac.User).Include(ac => ac.User.UserType).FirstOrDefault(b => b.Login == login && b.Password == password);
            if (a != null)
            {
                CurrentUser = a.User;
                return true;
            }
            else return false;
        }
        public void LoadBooks()
        {
            var listBooks = SQLDbConntext.DbContext.Books.Where(b => !b.Deleted).Include(b => b.Publisher).Include(b => b.Author).Include(b => b.Genre).OrderBy(o => o.Id).Skip(CurrentPage * BooksOnPage).Take(BooksOnPage);

            if (isSearch)
            {
                string text = tstbSearch.Text;
                switch (tscbSearchType.SelectedItem as string)
                {
                    case ("Название"):
                        listBooks = listBooks.Where(b => b.Name.Contains(text));
                        break;
                    case ("Автор"):
                        listBooks = listBooks.Where(b => b.Author.Name.Contains(text));
                        break;
                    case ("Жанр"):
                        listBooks = listBooks.Where(b => b.Genre.Name.Contains(text));
                        break;
                    case ("Издательство"):
                        listBooks = listBooks.Where(b => b.Publisher.Name.Contains(text));
                        break;
                }

                isSearch = false;
            }

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
            if (tstbSearch.Text != "" && tscbSearchType.SelectedIndex != -1)
            {
                isSearch = true;
            }
            LoadBooks();
        }

        private void tsbtnLogInLogOut_Click(object sender, EventArgs e)
        {
            if (tsbtnLogInLogOut.Text == "Выход")
            {
                CurrentUser = User.GetGuest();
                tsbtnLogInLogOut.Text = "Вход";
            }
            else
            {
                LogInOutForm liof = new LogInOutForm(this);
                liof.ShowDialog();
                tsbtnLogInLogOut.Text = "Выход";
            }
            ListBooks.Clear();
            UpdateUserNameText();
        }
        public static void Msg(MsgType msgType, MessageBoxIcon icon) => MessageBox.Show(Messages[(int)msgType],"", MessageBoxButtons.OK, icon);

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentUser.UserType.Name == "Admin")
            {
                BookControlDesc bcd = new BookControlDesc(this, new Book(), BookControlDesc.Mode.ADD);
                bcd.ShowDialog();
            }
            else Msg(MsgType.ERR_PERM, MessageBoxIcon.Warning);
        }

        private void tsbtnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.ShowDialog();
        }

        private void tsbtnCart_Click(object sender, EventArgs e)
        {
            Cart = new CartForm();
            if (CurrentUser.Name == "Гость") Msg(MsgType.ERR_ENTER, MessageBoxIcon.Warning);
            else Cart.Show();
        }
    }
}
