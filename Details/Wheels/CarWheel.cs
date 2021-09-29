using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Wheels
{
    class CarWheel: BaseWheel
    {
        public CarWheel(string label)
        :base(label, Compability.Car, 4)
        {
        }
    }
}
