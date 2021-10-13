using System;
using System.Collections.Generic;

namespace test_project
{
    class Mechanic_1: BaseMechanic
    {
        public Mechanic_1(string service)
        :base(service)
        {
        }

        public override void RepairTransport(BaseTransport transport)
        {
            RepareSteeringWheel(transport);
            RepareEngines(transport);
            RepareWheels(transport);
        }

        private void RepareSteeringWheel(BaseTransport transport)
        {
            if (transport.GetSteeringWheel() == null)
                return;

            //Перебор. Который нужен по-условию.
            foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
            {
                BaseSteeringWheel newSteeringWheel = Warehouse.CreateSteeringWheel(_service, type);
                if (transport.TryResetSteeringWheel(newSteeringWheel))
                    return;
            }
        }
        private void RepareEngines(BaseTransport transport)
        {
            int requiredEngines = transport.GetEnginesList().Count;
            //Ещё один перебор, который тоже нужен.
            foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
            {
                List<BaseEngine> newEnginesList = new List<BaseEngine>();
                for (int i = 0; i < requiredEngines; ++i)
                    newEnginesList.Add(Warehouse.CreateEngine(_service, type));

                if (transport.TryResetEnginesList(newEnginesList))
                    return;
            }
        }
        private void RepareWheels(BaseTransport transport)
        {
            int requiredWheels = transport.GetWheelsList().Count;
            //И ещё один перебор
            foreach (DetailCompability type in System.Enum.GetValues(typeof(DetailCompability)))
            {
                List<BaseWheel> newWheelsList = new List<BaseWheel>();
                for (int i = 0; i < requiredWheels; ++i)
                    newWheelsList.Add(Warehouse.CreateWheel(_service, type));

                if (transport.TryResetWheelsList(newWheelsList))
                    return;
            }
        }
    }
}
