using System;
using test_project.Transports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Mechanics
{
    interface IMechanic
    {
        BaseTransport work(BaseTransport transport);
    }
}
