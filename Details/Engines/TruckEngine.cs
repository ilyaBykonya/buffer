using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Engines
{
    class TruckEngine : BaseEngine
    {
        public TruckEngine(string label)
        :base(label, Compability.Truck, 80)
        {
        }
    }
}
