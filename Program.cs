// Вставьте сюда финальное содержимое файла MovingAverageTask.cs
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Program
{
    public static class Application
    {
        private static Goods CreateGoods()
        {
            Random randGenerator = new Random();
            string title = string.Empty;
            string type = string.Empty;
            Prices prices = new Prices();

            for (int i = 0; i < randGenerator.Next() % 15 + 5; ++i)
                title += (char)(randGenerator.Next() % 30 + 60);

            for (int i = 0; i < randGenerator.Next() % 15 + 5; ++i)
                type += (char)(randGenerator.Next() % 30 + 60);

            decimal startPrice = randGenerator.Next() % 1000;//Чтобы дикого разброса не было
            prices.Values[PriceCathegory.RetailPrice][ClientCathegory.SimpleClient] = startPrice;
            prices.Values[PriceCathegory.RetailPrice][ClientCathegory.CorporateClient] = startPrice - (startPrice * 0.02M);
            prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.SimpleClient] = startPrice - (startPrice * 0.07M);
            prices.Values[PriceCathegory.WholesalePrice][ClientCathegory.CorporateClient] = startPrice - (startPrice * 0.05M);

            return new Goods(title, type, (GoodsCathegory)(randGenerator.Next() % 3), (decimal)(randGenerator.NextDouble() / 4), prices);
        }
        private static GoodsRack CreateRack()
        {
            Random randGenerator = new Random();
            GoodsRack result = new GoodsRack();
            for (int i = 0; i < randGenerator.Next() % 6 + 5; ++i)
                result.GoodsOnRack.AddLast(CreateGoods());

            return result;
        }
        private static Shop CreateShop()
        {
            Random randGenerator = new Random();
            string title = string.Empty;
            for (int i = 0; i < randGenerator.Next() % 15 + 5; ++i)
                title += (char)(randGenerator.Next() % 30 + 60);

            Shop result = new Shop(title, (LoyalityStatus)(randGenerator.Next() % 3));
            for (int i = 0; i < randGenerator.Next() % 6 + 5; ++i)
                result.Racks.AddLast(CreateRack());

            return result;
        }


        static void Main(string[] args)
        {
            var shop = CreateShop();
            //Test_1(shop);
            //Test_2(shop);
            //Test_3(shop);
        }

        //Вывод, как требовалось в задании
        private static void Test_1(Shop shop)
        {
            shop.Print();
        }

        //Получает все цены на все товары для всех типов потребителей
        //и для всевозможных объёмов закупок. Короче, получает всё, что можно.
        //Как пример, можно посчитать среднюю цену по
        //товарам на весь магазин на всех покупателей.
        private static void Test_2(Shop shop)
        {
            uint countOfPrices = 0;
            decimal pricesSum = 0.0M;
            foreach (var elem in shop.GetResultPricesForAllGoods())
            {
                countOfPrices += 8;
                pricesSum += elem.Item3.RetailPrices[ClientCathegory.SimpleClient];
                pricesSum += elem.Item3.RetailPrices[ClientCathegory.CorporateClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.First][ClientCathegory.SimpleClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.First][ClientCathegory.CorporateClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.Second][ClientCathegory.SimpleClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.Second][ClientCathegory.CorporateClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.Third][ClientCathegory.SimpleClient];
                pricesSum += elem.Item3.WholesalePrices[WholesaleSize.Third][ClientCathegory.CorporateClient];
            }
            Console.WriteLine($"Average frice for shop: { pricesSum / countOfPrices }");
        }

        //Вычисление оптовой цены на все товары для простых клинетов
        private static void Test_3(Shop shop)
        {
            Console.WriteLine("Title\tCathegory\tPrice");
            foreach (var elem in shop.GetAllGoodsPrices(ClientCathegory.SimpleClient, 1000))
                Console.WriteLine($"{elem.Item1} | {elem.Item2} | {elem.Item3}");
        }

    }
}
