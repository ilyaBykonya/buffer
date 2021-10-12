using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    abstract class Ammunition: Item
    {
        public int Damage { get; protected set; }
        public string Type { get; protected set; }
        public Ammunition(string name, string type, int damage)
        :base(name)
        {
            Damage = damage;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type} ({Name}: Damage: {Damage})";
        }
    }
}
