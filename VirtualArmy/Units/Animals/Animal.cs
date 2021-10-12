using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Animal: Unit
    {
        public override int Damage { get; }
        public int Speed { get; protected set; }

        protected Animal(string name, int health, int armor, int damage, int speed)
        :base(name, health, armor)
        {
            Damage = damage;
            Speed = speed;
        }

        public override int Attack()
        {
            return Damage;
        }
        public override void TellAbout()
        {
            string description = $"Animal {Name}; " +
                                 $"hp = {Health}; " +
                                 $"damage = {Damage}; " +
                                 $"speed = {Speed};";

            Console.WriteLine(description);
        }
    }
}
