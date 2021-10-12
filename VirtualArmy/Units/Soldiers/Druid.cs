using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Druid: Soldier
    {
        public Druid()
        :base("Druid", 76, 0, 13, new SteelArmor())
        {
        }
    }
}
