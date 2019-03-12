using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class SQLDbConntext : DbContext
    {
        public static readonly SQLDbConntext DbContext = new SQLDbConntext();
        static SQLDbConntext()
        {
            string mode = ConfigurationManager.AppSettings["InitMode"];

            if (mode == "InitDropCreateDatabaseAlways")
                Database.SetInitializer(new InitDropCreateDatabaseAlways());
            else if (mode == "InitDropCreateDatabaseIfModelChanges")
                Database.SetInitializer(new InitDropCreateDatabaseIfModelChanges());
            else
                Database.SetInitializer(new InitDropCreateDatabaseAlways());
        }
        SQLDbConntext() : base("name=default") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public static void DBInit(SQLDbConntext context)
        {
            UserType usr = new UserType { Name = "User" };
            UserType adm = new UserType { Name = "Admin" };
            context.UserTypes.Add(usr);
            context.UserTypes.Add(adm);

            User a = new User { Name = "Никита", UserType = adm };
            User u = new User { Name = "Игорь", UserType = usr };
            context.Users.Add(a);
            context.Users.Add(u);

            Account admin = new Account { Login = "admin", Password = "123", User = a };
            Account user = new Account { Login = "user", Password = "123", User = u };
            context.Accounts.Add(admin);
            context.Accounts.Add(user);

            Genre fantstic = new Genre { Name = "Фантастика/Фэнтэзи" };
            Genre adventure = new Genre { Name = "Боевик" };
            Genre detective = new Genre { Name = "Детектив" };
            Genre programming = new Genre { Name = "Программирование" };
            context.Genres.Add(fantstic);
            context.Genres.Add(adventure);
            context.Genres.Add(detective);
            context.Genres.Add(programming);

            context.SaveChanges();
        }
        /// <summary>
        /// Метод который добавляет нового автора или возвращает уже существующего (для исключения дублирования)
        /// </summary>
        /// <param name="name">Принимает имя автора</param>
        /// <returns>Возвращает объект автора</returns>
        public static Author CheckUniqAuthor(string name)
        {
            Author a = DbContext.Authors.FirstOrDefault(b => b.Name == name);
            if (a == null)
            {
                a = new Author { Name = name };
                DbContext.Authors.Add(a);
                DbContext.SaveChanges();
            }

            return DbContext.Authors.FirstOrDefault(b => b.Name == name);
        }
        /// <summary>
        /// Метод который добавляет новый жанр или возвращает уже существующий (для исключения дублирования)
        /// </summary>
        /// <param name="name">Принимает имя жанра</param>
        /// <returns>Возвращает объект жанра</returns>
        public static Genre CheckUniqGenre(string name)
        {
            Genre g = DbContext.Genres.FirstOrDefault(b => b.Name == name);
            if (g == null)
            {
                g = new Genre { Name = name };
                DbContext.Genres.Add(g);
                DbContext.SaveChanges();
            }

            return DbContext.Genres.FirstOrDefault(b => b.Name == name);
        }
        /// <summary>
        /// Метод который добавляет нового издателя или возвращает уже существующего (для исключения дублирования)
        /// </summary>
        /// <param name="name">Принимает имя издателя</param>
        /// <returns>Возвращает объект издателя</returns>
        public static Publisher CheckUniqPublisher(string name)
        {
            Publisher p = DbContext.Publishers.FirstOrDefault(b => b.Name == name);
            if (p == null)
            {
                p = new Publisher { Name = name };
                DbContext.Publishers.Add(p);
                DbContext.SaveChanges();
            }

            return DbContext.Publishers.FirstOrDefault(b => b.Name == name);
        }
        //public T CheckUniq<T>(string name)
        //{
        //    Type t = typeof(T);
        //    Type dbContextType = DbContext.GetType();
        //    string className = t.Name;
        //    IQueryable<T> list = dbContextType.GetProperty(className + "s").GetValue(DbContext) as IQueryable<T>;

        //    T obj = (T)Activator.CreateInstance(t);
        //    foreach (dynamic item in list)
        //    {
        //        if (item.Name == name)
        //        {
        //            obj = item;
        //            break;
        //        }
        //    }

        //    if (obj == null)
        //    {
        //        T o = (T)Activator.CreateInstance(t);
        //        t.GetProperty("Name").SetValue(name, o);
        //        //o = new T { Name = name };
        //        //SQLDbContext.DbContext.Brands.Add(brand);
        //        //SQLDbContext.DbContext.SaveChanges();
        //    }

        //    return SQLDbContext.DbContext.Brands.FirstOrDefault(b => b.Name == name);
        //}
    }

    class InitDropCreateDatabaseAlways : DropCreateDatabaseAlways<SQLDbConntext>
    {
        protected override void Seed(SQLDbConntext context) => SQLDbConntext.DBInit(context);
    }
    class InitDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<SQLDbConntext>
    {
        protected override void Seed(SQLDbConntext context) => SQLDbConntext.DBInit(context);
    }
}
