using System;
using System.Collections.Generic;
using System.Text;

namespace SensorGenerator
{
    public class ChangeSensor
    {
        private int totalSensors = 4;

        private List<string> allTypes = new List<string>();
        private List<Sensor> allSensors = new List<Sensor>();

        public void CreateNewSensors()
        {
            this.CreateTypes();
            for (int i = 0; i < totalSensors; i++)
            {
                int higherNumber = i + 1;

                string identifier = "CHIBB-Node-" + higherNumber;
                string name = "Happy Plants Sensor Node";
                string type = allTypes[i];
                Random rnd = new Random();
                int value = rnd.Next(0, 100);
                string comment = "Nothing at the moment";
                Sensor newSensor = new Sensor(identifier, name, type, value, comment);
                allSensors.Add(newSensor);
            }
        }

        public void SetNewData()
        {
            for (int i = 0;  i < allSensors.Count; i++)
            {
                this.allSensors[i] = ChangeValues(this.allSensors[i]);
            }
        }

        public List<Sensor> GetAllSensors()
        {
            return this.allSensors;
        }

        private void CreateTypes()
        {
            this.allTypes.Add("Temperature");
            this.allTypes.Add("Soil Humidity");
            this.allTypes.Add("Light");
            this.allTypes.Add("PH");
        }

        private Sensor ChangeValues(Sensor currentSensor)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 3);
            if (value < 1.2)
            {
                currentSensor.Value -= 1;
            }
            else
            {
                if (value > 1.8)
                {
                    currentSensor.Value += 1;
                }
            }
            currentSensor.SetDateToday();
            return currentSensor;
        }
    }
}
