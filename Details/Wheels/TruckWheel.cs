namespace test_project
{
    class TruckWheel : BaseWheel
    {
        public TruckWheel(string label)
        :base(label, 8)
        {
        }
        public void priming()
        {
            //уменьшаем повреждения в 2 раза
            if(DamagedStatus > 10)
                DamagedStatus /= 2;
        }
    }
}
