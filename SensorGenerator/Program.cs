using System;
using System.Collections.Generic;

namespace SensorGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChangeSensor randomChanger = new ChangeSensor();
            randomChanger.CreateNewSensors();
            List<Sensor> allSensors = randomChanger.GetAllSensors();
            SendJsonToApi newSend = new SendJsonToApi(allSensors);
            newSend.SendJsonFirstTimeAsync().Wait();

            while (true)
            {
                randomChanger.SetNewData();
                allSensors = randomChanger.GetAllSensors();
                System.Threading.Thread.Sleep(10000);
                newSend = new SendJsonToApi(allSensors);
                newSend.SendJsonAsync().Wait();
            }
        }
    }
}