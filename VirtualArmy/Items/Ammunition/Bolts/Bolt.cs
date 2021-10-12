using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    abstract class Bolt : Ammunition
    {
        public Bolt(string name, int damage)
        :base(name, "Bolt", damage)
        {
        }
    }
}
