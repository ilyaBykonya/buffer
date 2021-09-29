using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Transports
{
    class Robot : BaseTransport
    {
        public Robot(TransportDetails details)
        :base(details)
        {
        }
        public override bool tryReplaceEngines(List<BaseEngine> newEnginesList)
        {
            _details._enginesList = newEnginesList;
            return true;
        }
        public override bool tryReplaceWheels(List<BaseWheel> newWheelsList)
        {
            _details._wheelsList = newWheelsList;
            return true;
        }
        public override bool tryReplaceSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            _details._steeringWheel = newSteeringWheel;
            return true;
        }
    }
}
