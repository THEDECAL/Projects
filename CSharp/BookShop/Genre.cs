namespace BookShop
{
    public class Genre
    {
        public int? Id { get; set; } = null;
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }
}