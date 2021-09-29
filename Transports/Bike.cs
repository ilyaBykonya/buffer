using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Transports
{
    class Bike : BaseTransport
    {
        public Bike(TransportDetails details)
        : base(details)
        {
        }

        public void forceOn()
        {
            foreach(BaseEngine engine in _details._enginesList)
            {
                Details.Engines.BikeEngine eng = (Details.Engines.BikeEngine)engine;
                if (eng != null)
                    eng.forceOn();
            }
        }
        public void forceOff()
        {
            foreach (BaseEngine engine in _details._enginesList)
            {
                Details.Engines.BikeEngine eng = (Details.Engines.BikeEngine)engine;
                if (eng != null)
                    eng.forceOff();
            }
        }
    }
}
