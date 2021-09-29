using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.SteeringWheels
{
    class CarSteeringWheel: BaseSteeringWheel, IBeep
    {
        public CarSteeringWheel(string label)
        :base(label, Compability.Car)
        {
        }

        public void beep()
        {
            Console.WriteLine("Car: beep");
        }
    }
}
