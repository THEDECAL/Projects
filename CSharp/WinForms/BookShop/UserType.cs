namespace BookShop
{
    public class UserType
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }
}