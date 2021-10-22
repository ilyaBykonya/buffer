using System;
using System.Collections.Generic;

namespace test_project
{
    class Car : BaseTransport
    {
        public Car(string label)
        {
            _steeringWheel = new CarSteeringWheel(label);
            _enginesList.Add(new CarEngine(label));
            _wheelsList.Add(new CarWheel(label));
            _wheelsList.Add(new CarWheel(label));
            _wheelsList.Add(new CarWheel(label));
            _wheelsList.Add(new CarWheel(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel is CarSteeringWheel)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 1)
                if (newEngines[0] is CarEngine)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 4)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine is CarWheel))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.Need;
        }
    }
}
