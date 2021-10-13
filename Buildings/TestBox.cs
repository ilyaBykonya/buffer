using System.Collections.Generic;

namespace test_project
{
    class TestBox
    {
        static public bool TestTransport(BaseTransport transport)
        {
            return (TestSteeringWheel(transport.GetSteeringWheel()) &&
                    TestWheels(transport.GetWheelsList()) &&
                    TestEngines(transport.GetEnginesList()));
        }

        static private bool TestEngines(List<BaseEngine> enginesList)
        {
            foreach (BaseEngine engine in enginesList)
            {
                if (engine is CarEngine)
                {
                    if (engine.PowerEngine != 40)
                        return false;
                }
                else if (engine is BikeEngine)
                {
                    //Короче, тест
                    BikeEngine eng = (BikeEngine)engine;
                    eng.ForceOff();//На всякий случай выключаем форсаж для точности измерений

                    if (eng.PowerEngine != 10)
                        return false;

                    eng.ForceOn();
                    if (eng.PowerEngine != 15)
                        return false;

                    eng.ForceOff();
                    if (eng.PowerEngine != 10)
                        return false;
                }
                else if (engine is TruckEngine)
                {
                    if (engine.PowerEngine != 80)
                        return false;
                }
            }

            return true;
        }
        static private bool TestWheels(List<BaseWheel> wheels)
        {
            foreach (BaseWheel wheel in wheels)
            {
                if (wheel is CarWheel)
                {
                    if (wheel.Mounts != 4)
                        return false;
                }
                else if (wheel is BikeWheel)
                {
                    if (wheel.Mounts != 1)
                        return false;
                }
                else if (wheel is TruckWheel)
                {
                    if (wheel.Mounts != 8)
                        return false;

                    ((TruckWheel)wheel).priming();
                }
            }
            return true;
        }
        static private bool TestSteeringWheel(BaseSteeringWheel steeringWheel)
        {
            if (steeringWheel is CarSteeringWheel)
            {
                ((CarSteeringWheel)steeringWheel).beep();
            }
            else if (steeringWheel is TruckSteeringWheel)
            {
                ((TruckSteeringWheel)steeringWheel).beep();
            }

            return true;
        }
    }
}
