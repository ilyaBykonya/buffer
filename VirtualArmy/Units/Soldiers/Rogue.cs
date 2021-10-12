using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Rogue: Soldier
    {
        public Rogue()
        :base("Rogue", 38, 0, 11, new GlassArmor())
        {
        }
    }
}
