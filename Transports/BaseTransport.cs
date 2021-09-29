using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project.Transports
{
    class TransportDetails
    {
        public BaseSteeringWheel _steeringWheel;
        public List<BaseEngine.Compability> _compabilitiesSteeringWheelList;

        public List<BaseEngine> _enginesList;
        public List<BaseEngine.Compability> _compabilitiesEngineList;

        public List<BaseWheel> _wheelsList;
        public List<BaseEngine.Compability> _compabilitiesWheelList;

        public TransportDetails()
        {
            _steeringWheel = null;
            _compabilitiesSteeringWheelList = new List<BaseEngine.Compability>();
            _enginesList = new List<BaseEngine>();
            _compabilitiesEngineList = new List<BaseEngine.Compability>();
            _wheelsList = new List<BaseWheel>();
            _compabilitiesWheelList = new List<BaseEngine.Compability>();
        }
    }

    abstract class BaseTransport
    {
        protected TransportDetails _details;
        public List<BaseEngine> Engines
        {
            get
            {
                return _details._enginesList;
            }
        }
        public BaseSteeringWheel SteeringWheel
        {
            get
            {
                return _details._steeringWheel;
            }
        }
        public List<BaseWheel> Wheels
        {
            get
            {
                return _details._wheelsList;
            }
        }

        protected BaseTransport(TransportDetails details)
        {
            _details = details;
        }

        public virtual bool tryReplaceEngines(List<BaseEngine> newEnginesList)
        {
            if (_details._enginesList == null)
                return true;
            if (_details._enginesList.Count == 0)
                return true;

            if (newEnginesList == null)
                return true;
            if (newEnginesList.Count == 0)
                return true;

            foreach (var newEngine in newEnginesList)
            {
                if (_details._enginesList.First().Label != newEngine.Label)
                    return false;

                bool isSuccess = false;
                foreach (var comp in _details._compabilitiesEngineList)
                {
                    if (comp == newEngine.CompabilityFlag)
                    {
                        isSuccess = true;
                        break;
                    }
                }
                if (isSuccess == false)
                    return false;
            }

            _details._enginesList = newEnginesList;
            return true;
        }
        public virtual bool tryReplaceWheels(List<BaseWheel> newWheelsList)
        {
            if (_details._wheelsList == null)
                return true;
            if (_details._wheelsList.Count == 0)
                return true;

            if (newWheelsList == null)
                return true;
            if (newWheelsList.Count == 0)
                return true;

            foreach (var newWheel in newWheelsList)
            {
                if (_details._wheelsList.First().Label != newWheel.Label)
                    return false;

                bool isSuccess = false;
                foreach (var comp in _details._compabilitiesWheelList)
                {
                    if(comp == newWheel.CompabilityFlag)
                    {
                        isSuccess = true;
                        break;
                    }
                }
                if (isSuccess == false)
                    return false;
            }

            _details._wheelsList = newWheelsList;
            return true;
        }
        public virtual bool tryReplaceSteeringWheel(BaseSteeringWheel newSteeringWheel)
        {
            if (_details._steeringWheel == null)
                return true;
            if (newSteeringWheel == null)
                return false;
            if (_details._steeringWheel.Label != newSteeringWheel.Label)
                return false;

            foreach (var comp in _details._compabilitiesSteeringWheelList)
            {
                if (comp == newSteeringWheel.CompabilityFlag)
                {
                    _details._steeringWheel = newSteeringWheel;
                    return true;
                }
            }
            return false;
        }
    }
}
