using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndThreads.Models
{
    [Synchronization()]
    class Pier
    {
        public delegate void ChangeList();
        public event ChangeList OnChangeList;
        Ship _ship = new Ship();
        public Ship Ship
        {
            get => _ship;
            set
            {
                _ship = value;
                OnChangeList();
            }
        }
    }
}
