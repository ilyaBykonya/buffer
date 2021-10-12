using System;
using System.Collections.Generic;

namespace VirtualArmy
{
    class Program
    {
        static void Main()
        {
            test_1();
        }

        static void test_1()
        {
            Army army_1 = createArmy("First army");
            Army army_2 = createArmy("Second army");
            Random rand = new Random();

            while(army_1.Health != 0 && army_2.Health != 0)
            {
                army_1.TellAbout();
                army_2.TellAbout();
                if(rand.Next() % 2 == 0)
                {
                    army_2.KillUnit(army_1.Damage);
                }
                else
                {
                    army_1.KillUnit(army_2.Damage);
                }
            }

            if(army_1.Health == 0)
            {
                Console.WriteLine(army_2.Name + " win");
            }
            else
            {
                Console.WriteLine(army_1.Name + " win");
            }
        }
        static Army createArmy(string name)
        {
            //Генерация армии.
            //Много варваров, потому что у них дамаг больше защиты,
            //Иначе была такая бага, что у обеих армий дамаг был меньше, чем
            //броня противника. И выходило бесконечное сражение.
            //
            //Тут бы отошёл от правил задания, и дал бы хотя бы 10 урона даже
            //при превосходстве защиты армии над дамажкой.
            return new Army(name,
            new List<Unit>{ new Druid(),
                            new Druid(),
                            new Canon(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Barbarian(),
                            new Catapult(),
                            new Catapult(),
                            new Catapult(),
                            new Catapult(),
                            new DruidOnHarts() });
        }
    }
}
