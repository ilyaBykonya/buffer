using System;
using System.Collections.Generic;

namespace test_project
{
    class Mechanic_2 : BaseMechanic
    {
        public Mechanic_2(string service)
        : base(service)
        {
        }

        public override void RepairTransport(BaseTransport transport)
        {
            Warehouse warehouse = new Warehouse();
            RepareSteeringWheel(transport, warehouse);
            RepareEngines(transport, warehouse);
            RepareWheels(transport, warehouse);
        }

        private void RepareSteeringWheel(BaseTransport transport, Warehouse warehouse)
        {
            if (transport.GetSteeringWheel() == null)
                return;

            foreach (DetailType detailType in System.Enum.GetValues(typeof(DetailType)))
            {
                foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
                {
                    if (transport.TryResetSteeringWheel((BaseSteeringWheel)Warehouse.CreateDetail(_service, type, detailType)))
                        return;
                }
            }
        }
        private void RepareEngines(BaseTransport transport, Warehouse warehouse)
        {
            int requiredEngines = transport.GetEnginesList().Count;
            foreach (DetailType detailType in System.Enum.GetValues(typeof(DetailType)))
            {
                foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
                {
                    List<BaseEngine> newEnginesList = new List<BaseEngine>();
                    for (int i = 0; i < requiredEngines; ++i)
                        newEnginesList.Add((BaseEngine)Warehouse.CreateDetail(_service, type, detailType));

                    if (transport.TryResetEnginesList(newEnginesList))
                        return;
                }
            }
        }
        private void RepareWheels(BaseTransport transport, Warehouse warehouse)
        {
            int requiredWheels = transport.GetWheelsList().Count;
            foreach (DetailType detailType in System.Enum.GetValues(typeof(DetailType)))
            {
                foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
                {
                    List<BaseWheel> newWheelsList = new List<BaseWheel>();
                    for (int i = 0; i < requiredWheels; ++i)
                        newWheelsList.Add((BaseWheel)(Warehouse.CreateDetail(_service, type, detailType)));

                    if (transport.TryResetWheelsList(newWheelsList))
                        return;
                }
            }
        }
    }
}
