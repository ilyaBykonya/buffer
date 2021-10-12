using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Mechanism: Unit
    {
        public override int Damage { get => (AmmunitionCount > 0) ? AmmunitionType.Damage : 0; }
        public int AmmunitionCount { get; protected set; }
        public Ammunition AmmunitionType { get; }

        protected Mechanism(string name, int health, int armor, Ammunition ammunitionType, int ammunitionAmount)
        :base(name, health, armor)
        {
            AmmunitionType = ammunitionType;
            AmmunitionCount = ammunitionAmount;
        }

        public override int Attack()
        {
            if(AmmunitionCount > 0)
            {
                --AmmunitionCount;
                return AmmunitionType.Damage;
            }
            else
            {
                return 0;
            }
        }
        public override void TellAbout()
        {
            string description = $"Mechanism {Name}; " +
                                 $"ammo = {AmmunitionType}; " +
                                 $"count = {AmmunitionCount}; " +
                                 $"hp = {Health}; " +
                                 $"armor = {Armor};";

            Console.WriteLine(description);
        }
    }
}
