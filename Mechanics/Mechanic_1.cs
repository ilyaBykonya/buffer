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
            Warehouse warehouse = new Warehouse();
            RepareSteeringWheel(warehouse, transport);
            RepareEngines(warehouse, transport);
            RepareWheels(warehouse, transport);
        }

        private void RepareSteeringWheel(Warehouse warehouse, BaseTransport transport)
        {
            if (transport.GetSteeringWheel() == null)
                return;

            foreach(var steeringWheel in warehouse.GetNextSteeringWheel(_service))
                if (transport.TryResetSteeringWheel((BaseSteeringWheel)steeringWheel))
                    return;
        }
        private void RepareEngines(Warehouse warehouse, BaseTransport transport)
        {
            int requiredEngines = transport.GetEnginesList().Count;
            if (requiredEngines == 0)
                return;

            foreach (var engine in warehouse.GetNextEngine(_service)) {
                List<BaseEngine> newEnginesList = new List<BaseEngine>();
                for (int i = 0; i < requiredEngines; ++i)
                    newEnginesList.Add((BaseEngine)engine);
                //Я знаю, что мы копируем ссылку и в реальном коде такое делать нельзя
                //Но пусть будет чисто для краткости, чтобы иметь возможность
                //не реализовывать для деталей ICloneable

                if (transport.TryResetEnginesList(newEnginesList))
                    return;
            }
        }
        private void RepareWheels(Warehouse warehouse, BaseTransport transport)
        {
            int requiredWheels = transport.GetWheelsList().Count;
            if (requiredWheels == 0)
                return;

            foreach (var wheel in warehouse.GetNextWheel(_service))
            {
                List<BaseWheel> newWheelsList = new List<BaseWheel>();
                for (int i = 0; i < requiredWheels; ++i)
                    newWheelsList.Add((BaseWheel)wheel);

                if (transport.TryResetWheelsList(newWheelsList))
                    return;
            }
        }
    }
}
