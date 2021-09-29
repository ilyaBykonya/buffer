using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Engines
{
    class CarEngine : BaseEngine
    {
        public CarEngine(string label)
        :base(label, Compability.Car, 40)
        {
        }
    }
}
