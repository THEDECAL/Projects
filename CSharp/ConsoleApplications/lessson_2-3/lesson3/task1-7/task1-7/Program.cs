using System;

namespace task1_7
{
    enum ArcticleType { Notebook, PC, Tablet, Smartphone };
    enum ClientType { Low, Middle, High };
    enum PayType { VISA, MasterCard, Cash };
    struct Article
    {
        uint id;
        ArcticleType type;
        string name;
        public decimal price { get; private set; }
    }
    struct Client
    {
        uint id;
        ClientType type;
        string fullName;
        string telNum;
        uint amOrders;
        decimal sumOrders;
    }
    struct RequestItem
    {
        Article article;
        uint amount;
    }
    struct Request
    {
        uint orderID;
        PayType type;
        Client client;
        DateTime date;
        Article[] articles;
        public decimal sum
        {
            get
            {
                foreach (var item in articles) sum += item.price;
                return sum;
            }
            private set { sum = value; }
        }
    }
}
