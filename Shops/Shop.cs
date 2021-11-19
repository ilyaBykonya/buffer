using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    enum LoyalityStatus
    {
        Gold,
        Silver,
        Bronze
    }
    enum WholesaleSize
    {
        First = 10,
        Second = 100,
        Third = 1000,
    }
    class FullPriceDescription
    {
        GoodsCathegory GoodsCathegory { get; }
        public Dictionary<ClientCathegory, decimal> RetailPrices { get; set; } = new();
        public Dictionary<WholesaleSize, Dictionary<ClientCathegory, decimal>> WholesalePrices { get; set; } = new();

        public FullPriceDescription(GoodsCathegory cathegory)
        {
            GoodsCathegory = cathegory;


            RetailPrices.Add(ClientCathegory.SimpleClient, 0.0M);
            RetailPrices.Add(ClientCathegory.CorporateClient, 0.0M);
            

            WholesalePrices.Add(WholesaleSize.First, new());
            WholesalePrices.Add(WholesaleSize.Second, new());
            WholesalePrices.Add(WholesaleSize.Third, new());

            WholesalePrices[WholesaleSize.First].Add(ClientCathegory.SimpleClient, 0.0M);
            WholesalePrices[WholesaleSize.First].Add(ClientCathegory.CorporateClient, 0.0M);

            WholesalePrices[WholesaleSize.Second].Add(ClientCathegory.SimpleClient, 0.0M);
            WholesalePrices[WholesaleSize.Second].Add(ClientCathegory.CorporateClient, 0.0M);

            WholesalePrices[WholesaleSize.Third].Add(ClientCathegory.SimpleClient, 0.0M);
            WholesalePrices[WholesaleSize.Third].Add(ClientCathegory.CorporateClient, 0.0M);
        }
    }

    class Shop
    {
        public string Title { get; }
        public LoyalityStatus Loyality { get; }
        public LinkedList<GoodsRack> Racks { get; set; } = new();
        public Shop(string title, LoyalityStatus loyality)
        {
            Title = title;
            Loyality = loyality;
        }

        public LinkedList<Tuple<string, GoodsCathegory, decimal>> GetAllGoodsPrices(ClientCathegory client, uint amountOfGoods)
        {
            LinkedList<Tuple<string, GoodsCathegory, decimal>> result = new();
            foreach (var rack in Racks)
            {
                foreach (var goods in rack.GoodsOnRack)
                {
                    PriceCathegory isWhole = (amountOfGoods > 9) ? PriceCathegory.WholesalePrice : PriceCathegory.RetailPrice;
                    decimal priceBuffer = goods.Duty + goods.Prices.Values[isWhole][client];
                    priceBuffer *= 
                        GetGoodClientAndPriceCathegoriesDiscount(goods.Cathegory, isWhole, client) *
                        GetBulkPurchaseDiscount(amountOfGoods) *
                        GetLoyalityStatusDiscount(Loyality);

                    result.AddLast(new Tuple<string, GoodsCathegory, decimal>(goods.Title, goods.Cathegory, priceBuffer));
                }
            }
            return result;
        }
        public LinkedList<Tuple<string, GoodsCathegory, FullPriceDescription>> GetResultPricesForAllGoods()
        {
            LinkedList<Tuple<string, GoodsCathegory, FullPriceDescription>> result = new();
            foreach(var rack in Racks)
            {
                foreach(var goods in rack.GoodsOnRack)
                {
                    FullPriceDescription prices = new(goods.Cathegory);
                    foreach (ClientCathegory clientCathegory in Enum.GetValues(typeof(ClientCathegory)))
                    {
                        decimal pricesBuffer = goods.Duty + goods.Prices.Values[PriceCathegory.RetailPrice][clientCathegory];

                        pricesBuffer *= 
                            GetGoodClientAndPriceCathegoriesDiscount(goods.Cathegory, PriceCathegory.RetailPrice, clientCathegory) *
                            GetLoyalityStatusDiscount(Loyality);

                        prices.RetailPrices[clientCathegory] = pricesBuffer;

                        foreach (WholesaleSize wholesaleSize in Enum.GetValues(typeof(WholesaleSize)))
                        {
                            pricesBuffer = goods.Prices.Values[PriceCathegory.WholesalePrice][clientCathegory];
                            pricesBuffer *=
                                GetGoodClientAndPriceCathegoriesDiscount(goods.Cathegory, PriceCathegory.WholesalePrice, clientCathegory) *
                                GetLoyalityStatusDiscount(Loyality) *
                                GetBulkPurchaseDiscount((uint)wholesaleSize);

                            prices.WholesalePrices[wholesaleSize][clientCathegory] = pricesBuffer;
                        }
                    }
                    result.AddLast(new Tuple<string, GoodsCathegory, FullPriceDescription>(goods.Title, goods.Cathegory, prices));
                }
            }
            return result;
        }
        public void Print()
        {
            Console.WriteLine($"Магазин {Title}");
            Console.WriteLine($"\tЛояльность: {Loyality}");

            int rackNumber = 0;
            Console.WriteLine();
            foreach (var rack in Racks)
            {
                Console.WriteLine($"\tСтойка {++rackNumber}");
                foreach (var goods in rack.GoodsOnRack)
                {
                    Console.WriteLine($"\t\tТовар: {goods.Title}");
                    Console.WriteLine($"\t\tТип: {goods.Type}");
                    Console.WriteLine($"\t\tКатегория: {goods.Cathegory}");
                    Console.WriteLine("\t\tПараметры:");
                    foreach(var parameter in goods.Properties)
                        Console.WriteLine($"\t\t\t{parameter.Key}: {parameter.Value}");

                    Console.WriteLine("\t\tЦена:");
                    Console.WriteLine("\t\t\tРозничная: ");
                    Console.WriteLine($"\t\t\t\tКлиентская: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.RetailPrice][ClientCathegory.SimpleClient], Loyality, goods.Cathegory, PriceCathegory.RetailPrice, ClientCathegory.SimpleClient, 1)}");
                    Console.WriteLine($"\t\t\t\tКорпоративная: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.RetailPrice][ClientCathegory.CorporateClient], Loyality, goods.Cathegory, PriceCathegory.RetailPrice, ClientCathegory.CorporateClient, 1)}" );
                    Console.WriteLine("\t\t\tОптовая:");
                    Console.WriteLine("\t\t\t\tКлиентская:");
                    Console.WriteLine($"\t\t\t\t\t10: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.SimpleClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.SimpleClient, 10)}");
                    Console.WriteLine($"\t\t\t\t\t100: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.SimpleClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.SimpleClient, 100)}");
                    Console.WriteLine($"\t\t\t\t\t1000: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.SimpleClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.SimpleClient, 1000)}");
                    Console.WriteLine("\t\t\t\tКорпоративная:");
                    Console.WriteLine($"\t\t\t\t\t10: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.CorporateClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.CorporateClient, 10)}");
                    Console.WriteLine($"\t\t\t\t\t100: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.CorporateClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.CorporateClient, 100)}");
                    Console.WriteLine($"\t\t\t\t\t1000: {CalculatePrice(goods.Duty + goods.Prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.CorporateClient], Loyality, goods.Cathegory, PriceCathegory.WholesalePrice, ClientCathegory.CorporateClient, 10000)}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        private static decimal CalculatePrice(decimal startPrice, LoyalityStatus loyality, GoodsCathegory goods, PriceCathegory price, ClientCathegory client, uint amountOfGoods)
        {
            return startPrice *
                GetGoodClientAndPriceCathegoriesDiscount(goods, price, client) *
                GetBulkPurchaseDiscount(amountOfGoods) *
                GetLoyalityStatusDiscount(loyality);
        }
        private static decimal GetGoodClientAndPriceCathegoriesDiscount(GoodsCathegory goods, PriceCathegory price, ClientCathegory client)
        {
            switch (goods)
            {
                case GoodsCathegory.Economy:
                    {
                        switch (client)
                        {
                            case ClientCathegory.SimpleClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.95M,
                                        PriceCathegory.WholesalePrice => 0.94M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            case ClientCathegory.CorporateClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.98M,
                                        PriceCathegory.WholesalePrice => 0.97M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            default:
                                throw new InvalidOperationException("Invalid client cathegory");
                        }
                    }
                case GoodsCathegory.Standard:
                    {
                        switch (client)
                        {
                            case ClientCathegory.SimpleClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.93M,
                                        PriceCathegory.WholesalePrice => 0.93M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            case ClientCathegory.CorporateClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.96M,
                                        PriceCathegory.WholesalePrice => 0.95M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            default:
                                throw new InvalidOperationException("Invalid client cathegory");
                        }
                    }
                case GoodsCathegory.Premium:
                    {
                        switch (client)
                        {
                            case ClientCathegory.SimpleClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.9M,
                                        PriceCathegory.WholesalePrice => 0.89M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            case ClientCathegory.CorporateClient:
                                {
                                    return price switch
                                    {
                                        PriceCathegory.RetailPrice => 0.95M,
                                        PriceCathegory.WholesalePrice => 0.94M,
                                        _ => throw new InvalidOperationException("Invalid price cathegory"),
                                    };
                                }
                            default:
                                throw new InvalidOperationException("Invalid client cathegory");
                        }
                    }
                default:
                    throw new InvalidOperationException("Invalid goods cathegory");
            }
        }
        private static decimal GetBulkPurchaseDiscount(uint amountOfGoods)
        {
            if (amountOfGoods >= 1000)
                return 0.95M;
            else if (amountOfGoods >= 100)
                return 0.97M;
            else if (amountOfGoods >= 10)
                return 0.98M;
            else
                return 1.0M;
        }
        private static decimal GetLoyalityStatusDiscount(LoyalityStatus loyality)
        {
            return loyality switch
            {
                LoyalityStatus.Gold => 0.85M,
                LoyalityStatus.Silver => 0.9M,
                LoyalityStatus.Bronze => 0.95M,
                _ => throw new InvalidOperationException("Invalid shop loyality"),
            };
        }
    }
}
