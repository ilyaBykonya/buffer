﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.SteeringWheels
{
    class BikeSteeringWheel: BaseSteeringWheel
    {
        public BikeSteeringWheel(string label)
        :base(label, Compability.Bike)
        {
        }
    }
}