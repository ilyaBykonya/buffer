using System;
using test_project.Transports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Builds
{
    enum TransportsType
    {
        Car,
        Bike,
        Truck,
        AllTerrainVehicle,
        Minivan,
        Boat,
        Cart,
        Airplane,
        Maize,
        Robot
    }

    class CarShop
    {
        static List<BaseEngine> getEngines(Warehouse warehouse, string label, BaseEngine.Compability compability, int count)
        {
            ProductDescription desc = new ProductDescription();
            desc._compability = compability;
            desc._label = label;
            desc._detailType = DetailType.Engine;
            List<BaseEngine> enginesList = new List<BaseEngine>();
            for (int i = 0; i < count; ++i)
                enginesList.Add((BaseEngine)warehouse.createDetailsList(desc));

            return enginesList;
        }
        static BaseSteeringWheel getSteeringWheel(Warehouse warehouse, string label, BaseEngine.Compability compability)
        {
            ProductDescription desc = new ProductDescription();
            desc._compability = compability;
            desc._label = label;
            desc._detailType = DetailType.SteeringWheel;
            return (BaseSteeringWheel)warehouse.createDetailsList(desc);
        }
        static List<BaseWheel> getWheelsList(Warehouse warehouse, string label, BaseEngine.Compability compability, int count)
        {
            ProductDescription desc = new ProductDescription();
            desc._compability = compability;
            desc._label = label;
            desc._detailType = DetailType.Wheel;
            List<BaseWheel> wheelsList = new List<BaseWheel>();
            for (int i = 0; i < count; ++i)
                wheelsList.Add((BaseWheel)warehouse.createDetailsList(desc));

            return wheelsList;
        }
        public BaseTransport buyTransport(TransportsType type, string label)
        {
            Warehouse warehouse = new Warehouse();
            switch (type)
            {
                case TransportsType.Car:
                    {
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Car);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, BaseDetail.Compability.Car, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Car, 4);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Car);


                        return new Car(details);
                    }
                case TransportsType.Bike:
                    {
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Bike);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Bike);

                        details._enginesList = getEngines(warehouse, label, BaseDetail.Compability.Bike, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Bike);

                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Bike, 2);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Bike);

                        return new Bike(details);
                    }
                case TransportsType.Truck:
                    {
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Truck);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Truck);

                        details._enginesList = getEngines(warehouse, label, BaseDetail.Compability.Truck, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Truck);

                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Truck, 6);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Truck);

                        return new Truck(details);
                    }
                case TransportsType.AllTerrainVehicle:
                    {
                        Random rand = new Random();
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Car);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, (rand.Next() % 2 == 0) ? BaseDetail.Compability.Truck : BaseDetail.Compability.Car, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Truck);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Truck, 4);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Truck);

                        return new AllTerrianVehicle(details);
                    }
                case TransportsType.Minivan:
                    {
                        Random rand = new Random();
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Car);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, (rand.Next() % 2 == 0) ? BaseDetail.Compability.Truck : BaseDetail.Compability.Car, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Truck);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, (rand.Next() % 2 == 0) ? BaseDetail.Compability.Truck : BaseDetail.Compability.Car, (rand.Next() % 2 == 0) ? 4 : 6);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Truck);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Car);

                        return new Minivan(details);
                    }
                case TransportsType.Boat:
                    {
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Bike);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Bike);

                        details._enginesList = getEngines(warehouse, label, BaseDetail.Compability.Car, 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        return new Boat(details);
                    }
                case TransportsType.Cart:
                    {
                        TransportDetails details = new TransportDetails();
                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Bike, 4);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Bike);

                        return new Cart(details);
                    }
                case TransportsType.Airplane:
                    {
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Car);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, BaseDetail.Compability.Truck, 4);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, BaseDetail.Compability.Truck, 10);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Car);


                        return new Airplane(details);
                    }
                case TransportsType.Maize:
                    {
                        Random rand = new Random();
                        TransportDetails details = new TransportDetails();
                        details._steeringWheel = getSteeringWheel(warehouse, label, BaseDetail.Compability.Car);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, (rand.Next() % 2 == 0) ? BaseDetail.Compability.Car : BaseDetail.Compability.Truck, 2);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Truck);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, (rand.Next() % 2 == 0) ? BaseDetail.Compability.Car : BaseDetail.Compability.Bike, 2);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Bike);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Car);


                        return new Maize(details);
                    }
                case TransportsType.Robot:
                    {
                        Random rand = new Random();
                        TransportDetails details = new TransportDetails();
                        BaseDetail.Compability robotDetailsCompability;
                        int randNum = rand.Next() % 3;
                        if (randNum == 0)
                            robotDetailsCompability = BaseDetail.Compability.Car;
                        else if (randNum == 1)
                            robotDetailsCompability = BaseDetail.Compability.Bike;
                        else
                            robotDetailsCompability = BaseDetail.Compability.Truck;

                        details._steeringWheel = getSteeringWheel(warehouse, label, robotDetailsCompability);
                        details._compabilitiesSteeringWheelList.Add(BaseDetail.Compability.Car);

                        details._enginesList = getEngines(warehouse, label, robotDetailsCompability, rand.Next() % 10 + 1);
                        details._compabilitiesEngineList.Add(BaseDetail.Compability.Car);

                        details._wheelsList = getWheelsList(warehouse, label, robotDetailsCompability, rand.Next() % 10 + 1);
                        details._compabilitiesWheelList.Add(BaseDetail.Compability.Car);


                        return new Robot(details);
                    }
                default: { throw new InvalidOperationException("Wrong TransportsType flag"); }
            }
        }
    }
}
