namespace BookShop
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual UserType UserType { get; set; }
        public override string ToString() => $"{Name} ({UserType})";
    }
}