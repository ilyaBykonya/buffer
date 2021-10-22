﻿using System;
using System.Collections.Generic;

namespace test_project
{
    class AllTerrianVehicle : BaseTransport
    {
        public AllTerrianVehicle(string label)
        {
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _wheelsList.Add(new TruckWheel(label));
            _steeringWheel = new CarSteeringWheel(label);
            if ((new Random()).Next(2) == 1)
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
            if (newSteeringWheel is CarSteeringWheel)
                return CheckDetailValidResult.Need;
            
            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines.Count == 1)
                if (newEngines[0] is TruckEngine || newEngines[0] is CarEngine)
                    return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
        protected override CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels.Count == 4)
                if (newWheels.TrueForAll(engine => engine.Label == newWheels[0].Label))
                    if (newWheels.TrueForAll(engine => engine is TruckWheel))
                        return CheckDetailValidResult.Need;

            return CheckDetailValidResult.WrongDetail;
        }
    }
}
