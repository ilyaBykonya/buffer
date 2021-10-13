using System;
using System.Collections.Generic;

namespace test_project
{
    class MaizePlane: BaseTransport
    {
        public MaizePlane(string label)
        {
            _steeringWheel = new CarSteeringWheel(label);
            Random rand = new Random();
            bool isCarWheels = (rand.Next(2) == 1);
            bool isCarEngines = (rand.Next(2) == 1);

            for (int i = 0; i < 2; ++i)
            {
                if(isCarEngines)
                {
                    _enginesList.Add(new CarEngine(label));
                }
                else
                {
                    _enginesList.Add(new TruckEngine(label));
                }
            }

            for (int i = 0; i < 2; ++i)
            {
                if (isCarWheels)
                {
                    _wheelsList.Add(new CarWheel(label));
                }
                else
                {
                    _wheelsList.Add(new BikeWheel(label));
                }
            }
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel.CompabilityFlag == DetailCompability.Car)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 2)
                if (newEngines.TrueForAll(engine => engine.CompabilityFlag == DetailCompability.Truck || engine.CompabilityFlag == DetailCompability.Car))
                    if (newEngines.TrueForAll(engine => engine.Label == newEngines[0].Label))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 2)
                if (newWheels.TrueForAll(engine => engine.CompabilityFlag == DetailCompability.Bike || engine.CompabilityFlag == DetailCompability.Car))
                    if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
