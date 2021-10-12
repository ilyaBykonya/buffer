using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Army: Unit
    {
        public override int Damage { get => Units.Sum(unit => unit.Damage); }
        protected List<Unit> Units { get; set; }
        public Army(string name, List<Unit> units)
        :base(name, 0, 0)
        {
            Units = units;
            UndateArmyCharacteristics();
        }

        public override void TellAbout()
        {
            string description = $"Army {Name}; " +
                                 $"hp = {Health}; " +
                                 $"damage = {Damage}; " +
                                 $"armor = {Armor}; " +
                                 $"count = {Units.Count};";

            Console.WriteLine(description);
        }
        public override int Attack()
        {
            return Damage;
        }
        public override int KillUnit(int damage)
        {
            damage -= Armor;
            if (damage <= 0)
                return 0;

            while(Units.Count > 0)
            {
                damage = Units.First().KillUnit(damage);
                if (Units.First().Health <= 0)
                    Units.RemoveAt(0);

                if (damage <= 0)
                    break;
            }

            UndateArmyCharacteristics();
            return damage;
        }

        protected void UndateArmyCharacteristics()
        {
            Health = Units.Sum(unit => unit.Health);
            Armor = Units.Sum(unit => unit.Armor);
        }
    }
}
