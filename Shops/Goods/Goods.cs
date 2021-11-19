using System;
using System.Collections.Generic;

namespace Program
{
    enum GoodsCathegory
    {
        Economy,
        Standard, 
        Premium
    }
    enum ClientCathegory
    {
        SimpleClient,
        CorporateClient
    }
    enum PriceCathegory
    {
        RetailPrice,
        WholesalePrice
    }
    
    
    class Prices
    {
        public Dictionary<PriceCathegory, Dictionary<ClientCathegory, decimal>> Values { get; set; } = new();
        public Prices()
        {
            Values.Add(PriceCathegory.RetailPrice, new());
            Values.Add(PriceCathegory.WholesalePrice, new());

            Values[PriceCathegory.RetailPrice].Add(ClientCathegory.SimpleClient, 0.0M);
            Values[PriceCathegory.RetailPrice].Add(ClientCathegory.CorporateClient, 0.0M);

            Values[PriceCathegory.WholesalePrice].Add(ClientCathegory.SimpleClient, 0.0M);
            Values[PriceCathegory.WholesalePrice].Add(ClientCathegory.CorporateClient, 0.0M);
        }
    }

    class Goods
    {
        public string Title { get; }
        public string Type { get; }
        public GoodsCathegory Cathegory { get; }

        public decimal Duty { get; }
        public Prices Prices { get; }
        public Dictionary<string, string> Properties { get; set; } = new();

        public Goods(string title, string type, GoodsCathegory cathegory, decimal duty, Prices prices)
        {
            Title = title;
            Type = type;
            Cathegory = cathegory;

            Duty = duty;
            Prices = prices;
        }
    }
}
