﻿using System;

namespace test_project
{
    public enum DetailCompability
    {
        Car,
        Truck,
        Bike
    };

    class BaseDetail
    {
        public DetailCompability CompabilityFlag { get; }//совместимость
        public int DamagedStatus { get; protected set; }//износ
        public string Label { get; }

        protected BaseDetail(DetailCompability compability, string label)
        {
            CompabilityFlag = compability;
            DamagedStatus = 0;
            Label = label;
        }
        public void repareDetail()
        {
            DamagedStatus = 0;
        }
    }
}

