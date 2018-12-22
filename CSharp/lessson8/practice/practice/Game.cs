using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace practice
{
    enum _menu { Start, AddPlayer, Exit };
    class Game : Deck
    {
        List<Player> players;
        Deck cardsOnTable;
        public Game()
        {
            players = new List<Player>();
            cardsOnTable = new Deck();
        }
        public void AddPlayer() //Метод добавления игрока
        {
            Console.Clear();
            if (players.Count < 4)
            {
                players.Add(new Player($"Игрок №{players.Count + 1}"));
                Console.Write("Игрок добавлен.");
            }
            else Console.Write("Максимум 4 игрока!");
            Thread.Sleep(2000);
        }
        public void GiveCards() //Метод раздачи карт
        {
            if (players.Count > 1 && deck.Count % players.Count == 0) //Если карт хватает раздать по ровну, то раздаём
            {
                while (deck.Count != 0)
                {
                    foreach (var item in players)
                    {
                        item.TakeACard(GiveLastCard());
                    }
                }
            }
        }
        public void ShowCardPlayers() //Метод показа карт для всех игроков (для отладки)
        {
            if (players.Count != 0)
            {
                foreach (var item in players)
                {
                    Console.WriteLine($"{item.Name} ({item.DeckSize} карт)");
                    item.ShowCards(true, 100);
                }
            }
        }
        public void Start() //Метод старта игры
        {
            InitDeck(); //Инициализация колоды
            GiveCards(); //Раздача карт

            for (;;)
            {
                Console.Clear();
                bool isGameOver = false;
                foreach (var item in players) //Ищем победителя
                {
                    if (item.DeckSize == 36)
                    {
                        Console.WriteLine($"Игру выиграл {item.Name}");
                        isGameOver = true;
                        break;
                    }
                }
                if (isGameOver) break;

                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].DeckSize != 0)
                    {
                        cardsOnTable.AddCard(players[i].GiveRandomCard()); //Игрок даёт случайную карту, "стол" получает
                    }
                }
                cardsOnTable.ShowCards(true,1000); //Показать карты на столе в нахлёст
                int playerWin = cardsOnTable.GetIndexMaxCard(); //Индекс игрока который берёт карты

                Console.WriteLine($"Карты берёт {players[playerWin].Name}");
                players[playerWin].AddCard(cardsOnTable); //Игроку передаются карты со стола
                cardsOnTable.Clear(); //Карты со стола вычищаются
                //ShowCardPlayers(); //Для отладки можно показать карты всех игроков
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
                Console.ReadKey();
            }
            Console.WriteLine("Игра окончена, нажмите любую кнопку, для возврата в меню.");
            Console.ReadKey();
        }
        public bool Menu() //Метод меню игры
        {
            players.Clear();
            players.Add(new Player("Игрок №1"));
            players.Add(new Player("Игрок №2"));
            Dictionary<int, Action> delegates = new Dictionary<int, Action>();

            string[] menu =
            {
                "Начать игру",
                "Добавить игрока (по умолчанию 2, максимум 4)",
                "Выход"
            };

            delegates[(int)_menu.Start] = Start;
            delegates[(int)_menu.AddPlayer] = AddPlayer;

            int arrow = 0, select = 0;
            for (;;)
            {
                Console.Clear();
                if (arrow > (int)_menu.Exit) arrow = (int)_menu.Start;
                else if (arrow < (int)_menu.Start) arrow = (int)_menu.Exit;

                for (int i = 0; i < menu.Count(); i++)
                {
                    Console.WriteLine($"{(arrow == i ? ">>" : "  ")} {i}. {menu[i]}");
                }

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow) arrow--;
                else if (key == ConsoleKey.DownArrow) arrow++;
                else if (key == ConsoleKey.Enter)
                {
                    select = arrow;
                    if (select >= (int)_menu.Start && select < (int)_menu.Exit) delegates[select]();
                    else if (select == (int)_menu.Exit) return true;
                }
            }
        }
    }
}
