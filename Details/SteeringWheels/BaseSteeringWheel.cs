using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    class BaseSteeringWheel: BaseDetail
    {
        protected BaseSteeringWheel(string label, Compability compability)
        :base(compability, label)
        {
        }
    }
}
