using System;
using System.Collections.Generic;

namespace test_project
{
    class Robot: BaseTransport
    {
        public Robot(string label)
        {
            Random rand = new Random();
            int wheelsCount = (rand.Next(2) == 1) ? 1 : 10;
            int enginesCount = (rand.Next(2) == 1) ? 1 : 10;

            _steeringWheel = new CarSteeringWheel(label);

            for (int i = 0; i < wheelsCount; ++i)
                _wheelsList.Add(new CarWheel(label));

            for (int i = 0; i < enginesCount; ++i)
                _enginesList.Add(new CarEngine(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            return CheckDetailValidResult.Need;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 1 || newEngines.Count == 10)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 1 || newWheels.Count == 10)
                return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
