namespace test_project
{
    class BaseWheel: BaseDetail
    {
        public int Mounts { get; protected set; }
        protected BaseWheel(string label, int mounts)
        :base(label)
        {
            Mounts = mounts;
        }
    }
}
