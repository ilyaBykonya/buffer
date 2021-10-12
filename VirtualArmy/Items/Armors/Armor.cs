using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Armor : Item
    {
        public int Defence { get; protected set; }
        public Armor(string name, int defence)
        :base(name)
        {
            Defence = defence;
        }

        public override string ToString()
        {
            return $"{Name}; Defence: {Defence})";
        }
    }
}
