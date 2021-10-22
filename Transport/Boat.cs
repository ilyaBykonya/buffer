using System;
using System.Collections.Generic;

namespace test_project
{
    class Boat : BaseTransport
    {
        public Boat(string label)
        {
            _enginesList.Add(new CarEngine(label));
            _steeringWheel = new BikeSteeringWheel(label);
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
            return CheckDetailValidResult.NotNeed;
        }
    }
}
