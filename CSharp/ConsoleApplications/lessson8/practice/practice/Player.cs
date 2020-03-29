using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Player : Deck
    {
        public string Name { get; private set; }
        public Player(string name)
        {
            Name = name;
        }
        public void TakeACard(Card card) //Метод получения карты
        {
            AddCard(card);
        }
    }
}
