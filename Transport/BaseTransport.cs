using System;
using System.Collections.Generic;

namespace test_project
{
    enum CheckDetailValidResult
    {
        Need,
        NotNeed,
        WrongDetail
    }

    //Класс реализует паттерн "шаблонный метод" при замене деталей
    //При этом наследники определяют валидность новой детали сами для себя
    abstract class BaseTransport
    {
        //Детальки. Если транспорту нужен, к примеру, только
        //один двигатель, то в CheckIsValidEnginesList он это укажет,
        //и всё будет гуд
        //
        //Также рассчитываем, что подклассы дадут валиндые детали при создании
        protected BaseSteeringWheel _steeringWheel = null;
        protected List<BaseEngine> _enginesList = new List<BaseEngine>();
        protected List<BaseWheel> _wheelsList = new List<BaseWheel>();


        //Проверка валидности деталей обеспечивается подклассами.
        //Мне было лень расписывать это в каждом классе, поэтому
        //я просто жмыхал пару циклов проверки и не парился
        //
        //Ну а теперь всё по канону....теперь у нас тут полиморфизм во всей красе
        protected abstract CheckDetailValidResult CheckIsValidSteeringWheel(BaseSteeringWheel newSteeringWheel);
        protected abstract CheckDetailValidResult CheckIsValidEnginesList(List<BaseEngine> newEngines);
        protected abstract CheckDetailValidResult CheckIsValidWheelsList(List<BaseWheel> newWheels);

        public bool TryResetSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (newSteeringWheel == null)
                return false;

            switch (CheckIsValidSteeringWheel(newSteeringWheel))
            {
                case CheckDetailValidResult.Need:
                    {
                        _steeringWheel = newSteeringWheel;
                        return true;
                    }
                case CheckDetailValidResult.NotNeed:
                    {
                        return true;
                    }
                case CheckDetailValidResult.WrongDetail:
                    {
                        return false;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
        public bool TryResetEnginesList(List<BaseEngine> newEngines)
        {
            if (newEngines == null)
                return false;

            switch (CheckIsValidEnginesList(newEngines))
            {
                case CheckDetailValidResult.Need:
                    {
                        _enginesList = newEngines;
                        return true;
                    }
                case CheckDetailValidResult.NotNeed:
                    {
                        return true;
                    }
                case CheckDetailValidResult.WrongDetail:
                    {
                        return false;
                    }
                default:
                    {
                        return true;
                    }
            }
        }
        public bool TryResetWheelsList(List<BaseWheel> newWheels)
        {
            if (newWheels == null)
                return false;

            switch (CheckIsValidWheelsList(newWheels))
            {
                case CheckDetailValidResult.Need:
                    {
                        _wheelsList = newWheels;
                        return true;
                    }
                case CheckDetailValidResult.NotNeed:
                    {
                        return true;
                    }
                case CheckDetailValidResult.WrongDetail:
                    {
                        return false;
                    }
                default:
                    {
                        return true;
                    }
            }
        }

        public BaseSteeringWheel GetSteeringWheel() { return _steeringWheel; }
        public List<BaseEngine> GetEnginesList() { return _enginesList; }
        public List<BaseWheel> GetWheelsList() { return _wheelsList; }
    }
}
