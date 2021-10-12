using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Soldier: Unit
    {
        public override int Damage { get; }
        public Armor AdditionalArmor { get; }

        protected Soldier(string name, int health, int armor, int damage, Armor additionalArmor)
        :base(name, health, armor + additionalArmor.Defence)
        {
            AdditionalArmor = additionalArmor;
            Damage = damage;
        }

        public override int Attack()
        {
            return Damage;
        }
        public override void TellAbout()
        {
            string description = $"Soldier {Name}; " +
                                 $"ammo = {AdditionalArmor}; " +
                                 $"hp = {Health}; " +
                                 $"damage = {Damage};";

            Console.WriteLine(description);
        }
    }
}
