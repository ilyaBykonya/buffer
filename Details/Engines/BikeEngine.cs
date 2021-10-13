namespace test_project
{
    class BikeEngine: BaseEngine
    {
        //Закончил читать одну книжку, узнал, что св-ва могут иметь
        //protected и private защиту. Так что избавляемся от флага
        public bool IsForced { get; private set; }
        public void ForceOn()
        {
            if (IsForced == true)
                return;

            IsForced = true;
            PowerEngine += 5;
        }
        public void ForceOff()
        {
            if (IsForced == false)
                return;

            IsForced = false;
            PowerEngine -= 5;
        }

        public BikeEngine(string label)
        :base(label, DetailCompability.Bike, 10)
        {
            IsForced = false;
        }
    }
}
