using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    class BaseDetail
    {
        public enum Compability
        {
            Car = 0,
            Truck = 1,
            Bike = 2
        };
        
        protected int _damagedStatus;//износ
        protected Compability _compabilityFlag;//совместимость
        protected string _label;


        protected BaseDetail(Compability compability, string label)
        {
            _damagedStatus = 0;
            _compabilityFlag = compability;
            _label = label;
        }

        public void repareDetail()
        {
            this._damagedStatus = 0;
        }
        public int DamagedStatus
        {
            get
            {
                return _damagedStatus;
            }
        }

        public string Label
        {
            get
            {
                return _label;
            }
        }
        public Compability CompabilityFlag
        {
            get
            {
                return _compabilityFlag;
            }
        }
    }
}

