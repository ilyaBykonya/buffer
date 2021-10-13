using System;
namespace test_project
{
    class TruckSteeringWheel: BaseSteeringWheel, IBeep
    {
        public TruckSteeringWheel(string label)
        :base(label, DetailCompability.Truck)
        {
        }
        public void beep()
        {
            Console.WriteLine("Truck: beeeeep");
        }
    }
}
