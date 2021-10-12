using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class Canon: Mechanism
    {
        public Canon()
        :base("Canon", 851, 0, new MagmaInvisibleAssault(), 15)
        {
        }
    }
}
