using System;
using test_project.Transports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Mechanics
{
    class FirstMechanic: IMechanic
    {
        public BaseTransport work(BaseTransport transport)
        {
            Warehouse shop = new Warehouse();

            if (transport.SteeringWheel != null)
            {
                for (int i = 0; i < 3; ++i)
                {
                    ProductDescription desc = new ProductDescription();
                    desc._label = transport.SteeringWheel.Label;
                    desc._detailType = DetailType.SteeringWheel;
                    desc._compability = (BaseDetail.Compability)i;

                    BaseSteeringWheel result = (BaseSteeringWheel)shop.createDetailsList(desc);
                    if (transport.tryReplaceSteeringWheel(result))
                        break;
                }
            }

            if (transport.Engines != null)
            {
                if (transport.Engines.Count != 0)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        ProductDescription desc = new ProductDescription();
                        desc._label = transport.Engines.First().Label;
                        desc._detailType = DetailType.Engine;
                        desc._compability = (BaseDetail.Compability)i;

                        List<BaseEngine> result = new List<BaseEngine>();
                        for (int k = 0; k < transport.Engines.Count; ++k)
                            result.Add((BaseEngine)shop.createDetailsList(desc));

                        if (transport.tryReplaceEngines(result))
                            break;
                    }
                }
            }

            if (transport.Wheels != null)
            {
                if (transport.Wheels.Count != 0)
                {
                    foreach (BaseWheel wheel in transport.Wheels)
                    {
                        bool isSuccess = false;
                        for (int i = 0; i < 3; ++i)
                        {
                            ProductDescription desc = new ProductDescription();
                            desc._label = wheel.Label;
                            desc._detailType = DetailType.Wheel;
                            desc._compability = (BaseDetail.Compability)i;

                            List<BaseWheel> newWheels = new List<BaseWheel>();
                            for (int k = 0; k < transport.Wheels.Count; ++k)
                                newWheels.Add((BaseWheel)shop.createDetailsList(desc));

                            if (transport.tryReplaceWheels(newWheels))
                            {
                                isSuccess = true;
                                break;
                            }
                        }
                        if (isSuccess == true)
                            break;
                    }
                }
            }

            return transport;
        }
    }
}
