﻿namespace BookShop
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}