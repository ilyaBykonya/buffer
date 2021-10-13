using System;
using System.Collections.Generic;

namespace test_project
{
    class Minivan : BaseTransport
    {
        public Minivan(string label)
        {
            _steeringWheel = new CarSteeringWheel(label);
            Random rand = new Random();

            int amountOfWheels = (rand.Next(2) == 1) ? 6 : 4;
            bool isTruckWheels = rand.Next(2) == 1;
            for (int i = 0; i < amountOfWheels; ++i)
            {
                if (isTruckWheels)
                {
                    _wheelsList.Add(new TruckWheel(label));
                }
                else
                {
                    _wheelsList.Add(new CarWheel(label));
                }
            }

            bool isTruckEnginee = rand.Next(2) == 1;
            if (isTruckEnginee)
            {
                _enginesList.Add(new TruckEngine(label));
            }
            else
            {
                _enginesList.Add(new CarEngine(label));
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
            if (newEngines.Count == 1)
                if (newEngines[0].CompabilityFlag == DetailCompability.Truck || newEngines[0].CompabilityFlag == DetailCompability.Car)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 4 || newWheels.Count == 6)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine.CompabilityFlag == DetailCompability.Truck || engine.CompabilityFlag == DetailCompability.Car))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
