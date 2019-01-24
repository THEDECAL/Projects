using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static home_work_IntroToADONet.SQLClientSingleton;

namespace home_work_IntroToADONet
{
    class Program
    {
        static string user;
        enum menu { LOGIN, ADD, REMOVE, UPDATE, SHOW, SEARCH, LOGS, LOGOUT, EXIT};
        enum mCode
        {
            WAIT,
            ERR_LOGIN,
            SUCC_LOGIN,
            ERR_FORMAT,
            SUCC_ADD_BOOK,
            ERR_ADD_BOOK,
            SUCC_DEL_BOOK,
            ERR_DEL_BOOK,
            SUCC_CHNG_BOOK,
            ERR_CHNG_BOOK,
            ERR_ID
        };
        static string[] _menu = new string[]
        {
            "Войти",
            "Добавить книгу",
            "Удалить книгу",
            "Обновить книгу",
            "Показать книги",
            "Поиск книг",
            "Журнал действий",
            "Выйти",
            "Закрыть"
        };
        static string[] messages = new string[]
        {
            "Нажмите <Enter> для продолжения",
            "Ошибка авторизации",
            "Вы успешно вошли в систему",
            "Ошибка формата ввода",
            "Вы успешно добавили книгу",
            "Ошибка при добавлении книги",
            "Вы успешно удалили книгу",
            "Ошибка удаления книги",
            "Вы успешно изменили книгу",
            "Ошибка изменения книги",
            "Не корректный ID"
        };
        static menu Menu()
        {
            int arrow = 0;

            for (;;)
            {
                Console.Clear();

                if (arrow > (int)menu.EXIT) arrow = 0;
                else if (arrow < 0) arrow = (int)menu.EXIT;

                Console.WriteLine($"Вы вошли как: {user}");
                Console.WriteLine(new string('-', 20) + '\n');

                int cnt = 0;
                foreach (var item in _menu)
                {
                    Console.WriteLine($"{(arrow == cnt ? ">" : " ")}{item}");
                    cnt++;
                }
                Console.WriteLine();

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow: arrow--; break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow: arrow++; break;
                    case ConsoleKey.Enter: return (menu)arrow;
                }
            }
        }
        static void Message(mCode m)
        {
            Console.WriteLine($"{messages[(int)m]}");
        }
        static void Wait()
        {
            Console.WriteLine($"\n{ messages[(int)mCode.WAIT]}");
            Console.ReadLine();
        }
        static void ShowResult(List<object> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (dynamic row in list)
                {
                    Type o = row.GetType();
                    foreach (var col in o.GetProperties())
                    {
                        object value = col.GetValue(row);
                        Console.WriteLine($"{col.Name}: {value.ToString()}");
                    }
                    Console.WriteLine(new string('-',20));
                }
            }
            else Console.WriteLine("Запрос не дал результата");
        }
        static void Main()
        {
            user = "Гость";
            for (;;)
            {
                menu select = Menu();
                switch (select)
                {
                    case menu.LOGIN:
                        Console.WriteLine("Введите логин: ");
                        string login = Console.ReadLine();

                        Console.WriteLine("Введите пароль: ");
                        string password = Console.ReadLine();

                        if (SQLConn.Autorization(login, password))
                        {
                            user = login;
                            Message(mCode.SUCC_LOGIN);
                        }
                        else Message(mCode.ERR_LOGIN);

                        break;
                    case menu.ADD:
                        if (user != "Гость")
                        {
                            try
                            {
                                Console.Write("Введите имя автора книги: ");
                                string fName = Console.ReadLine();

                                Console.Write("Введите фамилию автора книги: ");
                                string lName = Console.ReadLine();

                                Console.Write("Введите страну автора: ");
                                string country = Console.ReadLine();

                                Console.Write("Введите тему книги: ");
                                string theme = Console.ReadLine();

                                Console.Write("Введите название книги: ");
                                string bookName = Console.ReadLine();

                                Console.Write("Введите кол-во страниц: ");
                                int pages = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите цену книги (в формате 0,0): ");
                                decimal price = Convert.ToDecimal(Console.ReadLine());

                                Console.Write("Введите дату выпуска книги (в формате дд.мм.гггг): ");
                                DateTime dateOfPublish = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Введите тираж книги: ");
                                int drawingOfBook = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите кол-во книг на складе: ");
                                int quantityBooks = Convert.ToInt32(Console.ReadLine());

                                if(SQLConn.AddBook
                                    (
                                        fName,
                                        lName,
                                        country,
                                        theme,
                                        bookName,
                                        price,
                                        drawingOfBook,
                                        dateOfPublish,
                                        pages,
                                        quantityBooks
                                    )
                                ) Message(mCode.SUCC_ADD_BOOK);
                                else Message(mCode.ERR_ADD_BOOK);

                            }
                            catch (FormatException) { Message(mCode.ERR_FORMAT); }
                            catch (Exception) { Message(mCode.ERR_ADD_BOOK); }
                        }
                        else Message(mCode.ERR_LOGIN);

                        break;
                    case menu.REMOVE:
                        if (user != "Гость")
                        {
                            try
                            {
                                Console.WriteLine("Введите ID книги которую хотите удалить (больше 0): ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                if (id == 0) throw new Exception();

                                if (SQLConn.DelBook(id)) Message(mCode.SUCC_DEL_BOOK);
                                else Message(mCode.ERR_DEL_BOOK);
                            }
                            catch (Exception) { Message(mCode.ERR_ID); }
                            //catch (Exception e) { Console.WriteLine(e); }
                        }
                        else Message(mCode.ERR_LOGIN);

                        break;
                    case menu.UPDATE:
                        if (user != "Гость")
                        {
                            Console.WriteLine("Вы можете нажать <Enter> для полей которые не нужно обновлять.");
                            //Для заполнения только нужных полей при срабатывании исключения заполняется "пустотой"
                            try
                            {
                                Console.Write("Введите ID книги которую хотите изменить (больше 0): ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                if (id == 0) throw new Exception();
                                    
                                Console.Write("Введите новое название книги: ");
                                string bookName = Console.ReadLine();
                                if (bookName.Length == 0) bookName = null;

                                Console.Write("Введите новое кол-во страниц: ");
                                int? pages;
                                try
                                {
                                    pages = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception) { pages = null; }

                                Console.Write("Введите новую цену книги (в формате 0,0): ");
                                decimal? price;
                                try
                                {
                                    price = Convert.ToDecimal(Console.ReadLine());
                                }
                                catch (Exception) { price = null; }

                                Console.Write("Введите новую дату выпуска книги (в формате дд.мм.гггг): ");
                                DateTime? dateOfPublish;
                                try
                                {
                                    dateOfPublish = Convert.ToDateTime(Console.ReadLine());
                                }
                                catch (Exception) { dateOfPublish = null; }

                                Console.Write("Введите новый тираж книги: ");
                                int? drawingOfBook;
                                try
                                {
                                    drawingOfBook = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception) { drawingOfBook = null; }

                                Console.Write("Введите новое кол-во книг на складе: ");
                                int? quantityBooks;
                                try
                                {
                                    quantityBooks = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception) { quantityBooks = null; }

                                if (SQLConn.EditBook
                                    (
                                        id,
                                        bookName,
                                        price,
                                        drawingOfBook,
                                        dateOfPublish,
                                        pages,
                                        quantityBooks
                                    )
                                ) Message(mCode.SUCC_CHNG_BOOK);
                                else Message(mCode.ERR_CHNG_BOOK);
                            }
                            catch (Exception) { Message(mCode.ERR_ID); }
                        }
                        else Message(mCode.ERR_LOGIN);

                        break;
                    case menu.SHOW:
                        ShowResult(SQLConn.GetBooks());

                        break;
                    case menu.SEARCH:
                        Console.WriteLine("Введите название книги или автора для поиска: ");
                        string textSearch = Console.ReadLine();
                        ShowResult(SQLConn.GetSearchBooks(textSearch));

                        break;
                    case menu.LOGOUT:
                        user = "Гость";

                        break;
                    case menu.LOGS:
                        if (user != "Гость")
                        {
                            ShowResult(SQLConn.GetLogs());
                        }
                        else Message(mCode.ERR_LOGIN);

                        break;
                    case menu.EXIT: return;
                }
                Wait();
            }
        }
    }
}
