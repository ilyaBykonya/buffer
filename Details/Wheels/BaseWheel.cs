using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project
{
    class BaseWheel: BaseDetail
    {
        int _mounts;
        public int Mounts
        {
            get
            {
                return _mounts;
            }
        }

        protected BaseWheel(string label, Compability compability, int mounts)
        :base(compability, label)
        {
            _mounts = mounts;
        }

    }
}
