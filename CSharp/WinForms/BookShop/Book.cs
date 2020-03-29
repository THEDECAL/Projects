using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book
    {
        public int? Id { get; set; } = null;
        public bool Deleted { get; set; } = false;
        public string Name { get; set; } = "";
        public byte[] Image { get; set; } = null;
        public virtual Author Author { get; set; } = new Author();
        public int? Pages { get; set; } = null;
        public virtual Genre Genre { get; set; } = new Genre();
        public virtual Publisher Publisher { get; set; } = new Publisher();
        public int? Year { get; set; } = null;
        public double? CostPrice { get; set; } = null;
        public double? Price { get; set; } = null;
        public double? GetCostPrice() => (int)((Price == null) ? 0 : Price / 100) * 70;
        public override string ToString() => $"{Name} ({Author})";
    }
}
