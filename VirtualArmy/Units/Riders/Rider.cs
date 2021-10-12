using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Rider: Unit
    {
        public Animal RiderAnimal { get; protected set; }
        public Soldier RiderSoldier { get; protected set; }
        public override int Damage { get => RiderAnimal.Damage + RiderSoldier.Damage; }

        protected Rider(string name, Animal riderAnimal, Soldier riderSoldier)
        :base(name, riderAnimal.Health + riderSoldier.Health, riderAnimal.Armor + riderSoldier.Armor)
        {
            RiderAnimal = riderAnimal;
            RiderSoldier = riderSoldier;
        }

        public override int Attack()
        {
            return RiderAnimal.Damage + RiderSoldier.Damage;
        }
        public override void TellAbout()
        {
            string description = $"Rider {Name}; " +
                                 $"hp = {Health}; " +
                                 $"damage = {Damage};\n" +
                                 $"\tAnimal: " +
                                 $"\t{RiderAnimal}\n" +
                                 $"\tsoldier: " +
                                 $"\t{RiderSoldier}";

            Console.WriteLine(description);
        }
    }
}
