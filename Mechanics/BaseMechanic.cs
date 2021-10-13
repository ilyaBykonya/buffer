using System;
using System.Collections.Generic;


namespace test_project
{
    abstract class BaseMechanic
    {
        protected string _service;//Лейбл деталей, которые будет ставить механик
        protected BaseMechanic(string service)
        {
            _service = service;
        }

        public abstract void RepairTransport(BaseTransport transport);
    }
}
