namespace test_project
{
    class BaseEngine : BaseDetail
    {
        public int PowerEngine { get; protected set; }

        protected BaseEngine(string label, DetailCompability compability, int power)
        :base(compability, label)
        {
            PowerEngine = power;
        }
    }
}
