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
            RepareSteeringWheel(warehouse, transport);
            RepareEngines(warehouse, transport);
            RepareWheels(warehouse, transport);
        }

        private void RepareSteeringWheel(Warehouse warehouse, BaseTransport transport)
        {
            if (transport.GetSteeringWheel() == null)
                return;

            foreach(var detail in warehouse.GetNextDetail(_service))
                if (transport.TryResetSteeringWheel((BaseSteeringWheel)detail))
                    return;
        }
        private void RepareEngines(Warehouse warehouse, BaseTransport transport)
        {
            int requiredEngines = (transport.GetEnginesList() != null) ? transport.GetEnginesList().Count : 0;
            if (requiredEngines == 0)
                return;

            foreach (var detail in warehouse.GetNextDetail(_service))
            {
                List<BaseEngine> newEnginesList = new List<BaseEngine>();
                for (int i = 0; i < requiredEngines; ++i)
                    newEnginesList.Add((BaseEngine)detail);

                if (transport.TryResetEnginesList(newEnginesList))
                    return;
            }
        }
        private void RepareWheels(Warehouse warehouse, BaseTransport transport)
        {
            int requiredWheels = (transport.GetWheelsList() != null) ? transport.GetWheelsList().Count : 0;
            if (requiredWheels == 0)
                return;

            foreach (var detail in warehouse.GetNextDetail(_service))
            {
                List<BaseWheel> newWheelsList = new List<BaseWheel>();
                for (int i = 0; i < requiredWheels; ++i)
                    newWheelsList.Add((BaseWheel)detail);

                if (transport.TryResetWheelsList(newWheelsList))
                    return;
            }
        }
    }
}
