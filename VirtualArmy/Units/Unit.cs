using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    abstract class Unit
    {
        public virtual int Damage { get; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public string Name { get; }

        protected Unit(string name, int health, int armor)
        {
            Health = health;
            Armor = armor;
            Name = name;
        }

        public abstract void TellAbout();
        public abstract int Attack();

        //Возвращаем оставшийся общий урон
        public virtual int KillUnit(int damage)
        {
            if(damage >= Health)
            {
                damage -= Health;
                Health = 0;
                return damage;
            }
            else
            {
                Health -= damage;
                return 0;
            }
        }
    }
}
