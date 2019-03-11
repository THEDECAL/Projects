using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Discount { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
