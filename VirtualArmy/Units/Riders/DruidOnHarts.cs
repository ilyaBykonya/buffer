using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    class DruidOnHarts: Rider
    {
        public DruidOnHarts()
        :base("Druid on harts", new Harts(), new Druid())
        {
        }
    }
}
