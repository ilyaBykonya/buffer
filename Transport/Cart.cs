using System;
using System.Collections.Generic;

namespace test_project
{
    class Cart : BaseTransport
    {
        public Cart(string label)
        {
            _wheelsList.Add(new BikeWheel(label));
            _wheelsList.Add(new BikeWheel(label));
            _wheelsList.Add(new BikeWheel(label));
            _wheelsList.Add(new BikeWheel(label));
        }

        protected override CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            return CheckDetailValidResult.NotNeed;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            return CheckDetailValidResult.NotNeed;
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
