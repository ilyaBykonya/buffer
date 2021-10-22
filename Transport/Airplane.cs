using System;
using System.Collections.Generic;

namespace test_project
{
    class Airplane : BaseTransport
    {
        public Airplane(string label)
        {
            _steeringWheel = new CarSteeringWheel(label);

            for(int i = 0; i < 4; ++i)
                _enginesList.Add(new TruckEngine(label));

            for (int i = 0; i < 10; ++i)
                _wheelsList.Add(new TruckWheel(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel is CarSteeringWheel)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 4)
                if (newEngines[0] is TruckEngine)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 10)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine is TruckWheel))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
