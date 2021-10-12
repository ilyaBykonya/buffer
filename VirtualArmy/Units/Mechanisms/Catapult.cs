using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Catapult : Mechanism
    {
        public Catapult()
        :base("Catapult", 745, 0, new SonicDraconicBite(), 15)
        {
        }
    }
}
