using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    class test_project
    {
        static void test_1()
        {
            Builds.CarShop shop = new Builds.CarShop();
            Builds.Inspection inspection = new Builds.Inspection();

            Transports.BaseTransport tr = shop.buyTransport(Builds.TransportsType.Robot, "qwerty");
            Mechanics.FirstMechanic m1 = new Mechanics.FirstMechanic();
            Mechanics.SecondMechanic m2 = new Mechanics.SecondMechanic();
            Mechanics.ThirdMechanic m3 = new Mechanics.ThirdMechanic();

            //Горе-механики поставят все детали от машины, потому что перебирают их в цикле
            m1.work(tr);
            m2.work(tr);
            m3.work(tr);

            inspection.Test(tr);
        }
        static void test_2()
        {
            Builds.CarShop shop = new Builds.CarShop();
            Builds.Inspection inspection = new Builds.Inspection();

            Transports.Bike bike = (Transports.Bike)shop.buyTransport(Builds.TransportsType.Bike, "wsfrgwr");
            if (bike == null)
                throw new InvalidCastException("Invalid cast to bike in test_2");
            
            inspection.Test(bike);
            bike.forceOn();
            foreach (BaseEngine eng in bike.Engines)
                Console.WriteLine($"Power engine: { eng.PowerEngine }");
            bike.forceOff();
            foreach (BaseEngine eng in bike.Engines)
                Console.WriteLine($"Power engine: { eng.PowerEngine }");
        }


        static void Main(string[] args)
        {
        }
    }
}
