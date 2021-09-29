using System;
using test_project.Transports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Mechanics
{
    class ThirdMechanic: IMechanic
    {
        public BaseTransport work(BaseTransport transport)
        {
            foreach (BaseWheel wheel in transport.Wheels)
                if(wheel.CompabilityFlag == BaseDetail.Compability.Truck)
                    wheel.repareDetail();

            return transport;
        }
    }
}
