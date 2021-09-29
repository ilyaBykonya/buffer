using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    class BaseEngine : BaseDetail
    {
        protected int _powerEngine;
        public int PowerEngine
        {
            get
            {
                return _powerEngine;
            }
        }

        protected BaseEngine(string label, Compability compability, int power)
        :base(compability, label)
        {
            _powerEngine = power;
        }
    }
}
