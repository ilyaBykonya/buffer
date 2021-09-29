using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.SteeringWheels
{
    class TruckSteeringWheel: BaseSteeringWheel, IBeep
    {
        public TruckSteeringWheel(string label)
        :base(label, Compability.Truck)
        {
        }
        public void beep()
        {
            Console.WriteLine("Truct: beeeeep");
        }
    }
}
