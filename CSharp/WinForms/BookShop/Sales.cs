using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Sales
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public DateTime Date { get; set; }
    }
}
