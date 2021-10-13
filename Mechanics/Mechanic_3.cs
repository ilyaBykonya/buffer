using System;
using System.Collections.Generic;

namespace test_project
{
    class Mechanic_3 : BaseMechanic
    {
        public Mechanic_3(string service)
        : base(service)
        {
        }

        public override void RepairTransport(BaseTransport transport)
        {
            foreach (BaseWheel wheel in transport.GetWheelsList())
            {
                TruckWheel primingWheel = wheel as TruckWheel;
                if (primingWheel != null)
                    primingWheel.priming();
            }
        }
    }
}
