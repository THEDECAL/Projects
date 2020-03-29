using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace practice
{
    class Deck
    {
        protected SortedList<int, Card> deck;
        public int DeckSize => deck.Count; //Метод показа размера колоды 
        public Deck()
        {
            deck = new SortedList<int, Card>();
        }
        public IEnumerator<Card> GetEnumerator()
        {
            foreach (int item in deck.Keys)
            {
                yield return deck[item];
            }
        }
        public void Clear()
        {
            deck.Clear();
        }
        public void InitDeck() //Метод инициализации и тасовки колоды карт
        {
            deck.Clear();
            for (int i = (int)Rank._6; i <= (int)Rank.Ace; i++)
            {
                for (int j = (int)Suit.Hearts; j <= (int)Suit.Spades; j++)
                {
                    int rnum = new Random().Next();
                    if (!deck.ContainsKey(rnum))
                    {
                        deck.Add(rnum, new Card((Rank)i, (Suit)j));
                    }
                    else j--;
                }
            }
        }
        public void AddCard(Card card) //Метод добавления карты
        {
            int key = deck.Count;
            for (;;)
            {
                if (!deck.ContainsKey(key))
                {
                    deck.Add(key, card);
                    break;
                }
                else key++;
            }
        }
        public void AddCard(Deck o) //Метод добавления карт
        {
            foreach (int item in o.deck.Keys)
            {
                AddCard(o.deck[item]);
            }
        }
        public Card GiveLastCard() //Метод выдачи последней карты
        {
            Card temp = deck[deck.Keys.Last()];
            deck.Remove(deck.Keys.Last());
            deck.TrimExcess();
            return temp;
        }
        public Card GiveRandomCard() //Метод выдачи случайной карты
        {
            int cnt = 0, key = GetIndexMaxCard(); //Если счётчик не совпадёт со случайным числом, то выдать самую большую карту
            foreach (int item in deck.Keys)
            {
                if (cnt == new Random().Next(0, deck.Count))
                {
                    key = item;
                    break;
                }
                cnt++;
            }
            Card temp = deck[key];
            deck.Remove(key);
            deck.TrimExcess();
            return temp;
        }
        public void ShowCards(bool cardsOnTable = false,int sleep = 0) //Метод показа карт
        {
            int cardWidth = (cardsOnTable == false) ? 11 : 6; //Если карты на столе, то показывать карты в нахлёст
            const int cardHeight = 9;
            int leftPos = 0;
            int topPos = Console.CursorTop;
            int cnt = 1, amCardOnDisplay = 8;
            foreach (int item in deck.Keys)
            {
                Thread.Sleep(sleep);
                deck[item].ShowCard(leftPos);
                leftPos += cardWidth;
                if (cnt % amCardOnDisplay == 0)
                {
                    leftPos = 0;
                    topPos += cardHeight;
                }
                Console.CursorTop = topPos;
                cnt++;
            }
            if(deck.Count % amCardOnDisplay != 0) Console.CursorTop += cardHeight;
            Console.CursorLeft = 0;
        }
        public int GetIndexMaxCard()
        {
            int maxIndexCard = deck.Keys.First();
            foreach (int item in deck.Keys)
            {
                if (deck[maxIndexCard] < deck[item])
                    maxIndexCard = item;
            }
            return maxIndexCard;
        }
    }
}
