using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Details.Engines
{
    class BikeEngine : BaseEngine
    {
        private bool _isForced;
        public bool IsForced
        {
            get
            {
                return _isForced;
            }
        }

        public BikeEngine(string label)
        :base(label, Compability.Bike, 10)
        {
            _isForced = false;
        }


        public void forceOn()
        {
            if (_isForced == true)
                return;

            _isForced = true;
            this._powerEngine += 5;
        }
        public void forceOff()
        {
            if (_isForced == false)
                return;

            _isForced = false;
            this._powerEngine -= 5;
        }
    }
}
