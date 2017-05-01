using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SensorGenerator
{
    public class SendJsonToApi
    {
        private List<Sensor> allSensors;
        private string Url;
        private string Json;

        public SendJsonToApi(List<Sensor> newAllSensors)
        {
            this.allSensors = newAllSensors;
        }

        public async System.Threading.Tasks.Task SendJsonAsync()
        {
            this.Url = "Sensorvalues/CreateWithJson";

            foreach (var sensor in allSensors)
            {

                JObject test = new JObject();

                test = JObject.FromObject(new { valueKey = Sensor.PC, Identifier = sensor.Identifier, Ipadress = sensor.IpAdress, Sensordata = sensor.Value, Datadate = sensor.Date });

                Sensor.SetPcUp();
                string json = JsonConvert.SerializeObject(test);
                this.Json = json;
                this.SendBasic().Wait();
            }
        }

        public async System.Threading.Tasks.Task SendJsonFirstTimeAsync()
        {
            this.Url = "Sensors/CreateWithJson";

            foreach (var sensor in allSensors)
            {

                JObject test = new JObject();

                test = JObject.FromObject(new { Identifier = sensor.Identifier, Sensorname = sensor.Name, Sensortype = sensor.Type, Sensorcomment = sensor.Comment });

                string json = JsonConvert.SerializeObject(test);
                this.Json = json;
                this.SendBasic().Wait();
            }
        }

        public async System.Threading.Tasks.Task SendBasic()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49814/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP POST
                var response = await client.PostAsync(this.Url, new StringContent(this.Json, Encoding.UTF8, "application/json")); ;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ToString());
                }
                else
                {
                    Console.WriteLine(response.ToString());
                }
            }
        }
    }
}
