using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Wheels
{
    class TruckWheel : BaseWheel
    {
        public TruckWheel(string label)
        :base(label, Compability.Truck, 8)
        {
        }

        public void priming()
        {
            //уменьшаем повреждения в 2 раза
            if(_damagedStatus > 10)
                _damagedStatus /= 2;
        }
    }
}
