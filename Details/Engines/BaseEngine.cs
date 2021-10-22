namespace test_project
{
    class BaseEngine : BaseDetail
    {
        public int PowerEngine { get; protected set; }

        protected BaseEngine(string label, int power)
        :base(label)
        {
            PowerEngine = power;
        }
    }
}
