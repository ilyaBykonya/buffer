using System;
using System.Collections.Generic;

namespace test_project
{
    class Bike: BaseTransport
    {
        public Bike(string label)
        {
            _steeringWheel = new BikeSteeringWheel(label);
            _enginesList.Add(new BikeEngine(label));
            _wheelsList.Add(new BikeWheel(label));
            _wheelsList.Add(new BikeWheel(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel.CompabilityFlag == DetailCompability.Bike)
                return CheckDetailValidResult.Need;
            
            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 1)
                if (newEngines[0].CompabilityFlag == DetailCompability.Bike)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 4)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine.CompabilityFlag == DetailCompability.Bike))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
