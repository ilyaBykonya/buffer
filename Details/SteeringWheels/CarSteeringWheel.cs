﻿using System;
namespace test_project
{
    class CarSteeringWheel: BaseSteeringWheel, IBeep
    {
        public CarSteeringWheel(string label)
        :base(label)
        {
        }
        public void beep()
        {
            Console.WriteLine("Car: beep");
        }
    }
}
