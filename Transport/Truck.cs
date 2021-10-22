using System;
using System.Collections.Generic;

namespace test_project
{
    class Truck : BaseTransport
    {
        public Truck(string label)
        {
            _steeringWheel = new TruckSteeringWheel(label);
            _enginesList.Add(new TruckEngine(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel is TruckSteeringWheel)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 1)
                if (newEngines[0] is TruckEngine)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 6)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine is TruckWheel))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
