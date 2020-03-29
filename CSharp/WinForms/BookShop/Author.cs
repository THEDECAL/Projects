using System.Collections.Generic;

namespace BookShop
{
    public class Author
    {
        public int? Id { get; set; } = null;
        public string Name { get; set; } = "";
        public override string ToString() => $"{Name}";
    }
}