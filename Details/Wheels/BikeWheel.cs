using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Wheels
{
    class BikeWheel: BaseWheel
    {
        public BikeWheel(string label)
        :base(label, Compability.Bike, 1)
        {
        }
    }
}
