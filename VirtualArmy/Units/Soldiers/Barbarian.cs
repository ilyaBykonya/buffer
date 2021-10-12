using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Barbarian: Soldier
    {
        public Barbarian()
        :base("Barbarian", 201, 0, 17, new HideArmor())
        {
        }
    }
}
