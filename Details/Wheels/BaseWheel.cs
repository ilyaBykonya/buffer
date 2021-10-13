namespace test_project
{
    class BaseWheel: BaseDetail
    {
        public int Mounts { get; protected set; }
        protected BaseWheel(string label, DetailCompability compability, int mounts)
        :base(compability, label)
        {
            Mounts = mounts;
        }
    }
}
