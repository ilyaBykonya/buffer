using System;
using test_project.Details.Engines;
using test_project.Details.Wheels;
using test_project.Details.SteeringWheels;
using test_project.Transports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Builds
{
    class Inspection
    {
        public bool Test(BaseTransport transport)
        {
            if (TestEngines(transport.Engines) == false)
                return false;
            if (TestSteeringWheel(transport.SteeringWheel) == false)
                return false;
            if (TestWheels(transport.Wheels) == false)
                return false;

            return true;
        }

        bool TestWheels(List<BaseWheel> wheels)
        {
            foreach(BaseWheel wheel in wheels)
            {
                if (wheel is CarWheel)
                {
                }
                else if (wheel is BikeWheel)
                {
                }
                else if (wheel is TruckWheel)
                {
                    TruckWheel w = (TruckWheel)wheel;
                    w.priming();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        bool TestSteeringWheel(BaseSteeringWheel steeringWheel)
        {
            if (steeringWheel is CarSteeringWheel)
            {
                CarSteeringWheel w = (CarSteeringWheel)steeringWheel;
                w.beep();
            }
            else if (steeringWheel is BikeSteeringWheel)
            {
            }
            else if (steeringWheel is TruckSteeringWheel)
            {
                TruckSteeringWheel w = (TruckSteeringWheel)steeringWheel;
                w.beep();
            }
            else
            {
                return false;
            }

            return true;
        }
        bool TestEngines(List<BaseEngine> enginesList)
        {
            foreach (BaseEngine engine in enginesList)
            {
                if (engine is CarEngine)
                {
                    CarEngine eng = (CarEngine)engine;
                    if (eng.PowerEngine != 40)
                        return false;
                }
                else if (engine is BikeEngine)
                {
                    BikeEngine eng = (BikeEngine)engine;
                    if (eng.PowerEngine != 10)
                        return false;

                    eng.forceOn();
                    if (eng.PowerEngine != 15)
                        return false;

                    eng.forceOff();
                    if (eng.PowerEngine != 10)
                        return false;
                }
                else if (engine is TruckEngine)
                {
                    TruckEngine eng = (TruckEngine)engine;
                    if (eng.PowerEngine != 80)
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
