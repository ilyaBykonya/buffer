using System;


namespace test_project
{
    public enum DetailCompability
    {
        Car = 0,
        Truck = 1,
        Bike = 2
    };
    public enum DetailType
    {
        Wheel,
        Engine,
        SteeringWheel
    }
    
    class Warehouse
    {
        static public BaseDetail CreateDetail(string label, DetailCompability compability, DetailType type)
        {
            switch (type)
            {
                case DetailType.Wheel:
                    {
                        return CreateWheel(label, compability);
                    }
                case DetailType.Engine:
                    {
                        return CreateEngine(label, compability);
                    }
                case DetailType.SteeringWheel:
                    {
                        return CreateSteeringWheel(label, compability);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        static public BaseWheel CreateWheel(string label, DetailCompability compability)
        {
            switch (compability)
            {
                case DetailCompability.Bike:
                    {
                        return new BikeWheel(label);
                    }
                case DetailCompability.Car:
                    {
                        return new CarWheel(label);
                    }
                case DetailCompability.Truck:
                    {
                        return new TruckWheel(label);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        static public BaseEngine CreateEngine(string label, DetailCompability compability)
        {
            switch (compability)
            {
                case DetailCompability.Bike:
                    {
                        return new BikeEngine(label);
                    }
                case DetailCompability.Car:
                    {
                        return new CarEngine(label);
                    }
                case DetailCompability.Truck:
                    {
                        return new TruckEngine(label);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        static public BaseSteeringWheel CreateSteeringWheel(string label, DetailCompability compability)
        {
            switch (compability)
            {
                case DetailCompability.Bike:
                    {
                        return new BikeSteeringWheel(label);
                    }
                case DetailCompability.Car:
                    {
                        return new CarSteeringWheel(label);
                    }
                case DetailCompability.Truck:
                    {
                        return new TruckSteeringWheel(label);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
