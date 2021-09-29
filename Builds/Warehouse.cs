using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    public enum DetailType
    {
        Wheel,
        Engine,
        SteeringWheel
    }

    struct ProductDescription
    {
        public string _label;
        public BaseDetail.Compability _compability;
        public DetailType _detailType;
    }
    class Warehouse
    {
        public BaseDetail createDetailsList(ProductDescription desc)
        {
            switch (desc._detailType)
            {
                case DetailType.Wheel:
                {
                    switch (desc._compability)
                    {
                        case BaseDetail.Compability.Bike:
                            {
                                return new Details.Wheels.BikeWheel(desc._label);
                            }
                        case BaseDetail.Compability.Car:
                            {
                                return new Details.Wheels.CarWheel(desc._label);
                            }
                        case BaseDetail.Compability.Truck:
                            {
                                return new Details.Wheels.TruckWheel(desc._label);
                            }
                    }
                    break;
                }
                case DetailType.Engine:
                {
                    switch (desc._compability)
                    {
                        case BaseDetail.Compability.Bike:
                            {
                                return new Details.Engines.BikeEngine(desc._label);
                            }
                        case BaseDetail.Compability.Car:
                            {
                                return new Details.Engines.CarEngine(desc._label);
                            }
                        case BaseDetail.Compability.Truck:
                            {
                                return new Details.Engines.TruckEngine(desc._label);
                            }
                    }
                    break;
                }
                case DetailType.SteeringWheel:
                {
                    switch (desc._compability)
                    {
                        case BaseDetail.Compability.Bike:
                            {
                                return new Details.SteeringWheels.BikeSteeringWheel(desc._label);
                            }
                        case BaseDetail.Compability.Car:
                            {
                                return new Details.SteeringWheels.CarSteeringWheel(desc._label);
                            }
                        case BaseDetail.Compability.Truck:
                            {
                                return new Details.SteeringWheels.TruckSteeringWheel(desc._label);
                            }
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            throw new InvalidOperationException("Wrong DetailType flag");
        }
    }
}
