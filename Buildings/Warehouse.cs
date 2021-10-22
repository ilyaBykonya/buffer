using System;
using System.Collections;


namespace test_project
{
    class Warehouse
    {
        public IEnumerable GetNextDetail(string label)
        {
            while(true)
            {
                yield return GetNextWheel(label);
                yield return GetNextEngine(label);
                yield return GetNextSteeringWheel(label);
            }
        }
        public IEnumerable GetNextWheel(string label)
        {
            while (true)
            {
                yield return new CarWheel(label);
                yield return new BikeWheel(label);
                yield return new TruckWheel(label);
            }
        }
        public IEnumerable GetNextEngine(string label)
        {
            while (true)
            {
                yield return new CarEngine(label);
                yield return new BikeEngine(label);
                yield return new TruckEngine(label);
            }
        }
        public IEnumerable GetNextSteeringWheel(string label)
        {
            while (true)
            {
                yield return new CarSteeringWheel(label);
                yield return new BikeSteeringWheel(label);
                yield return new TruckSteeringWheel(label);
            }
        }
    }
}
