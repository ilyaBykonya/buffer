using System;

namespace test_project
{
    class BaseDetail
    {
        public int DamagedStatus { get; protected set; }//износ
        public string Label { get; }

        protected BaseDetail(string label)
        {
            DamagedStatus = 0;
            Label = label;
        }
        public void repareDetail()
        {
            DamagedStatus = 0;
        }
    }
}

