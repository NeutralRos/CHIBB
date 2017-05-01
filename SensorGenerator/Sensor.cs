using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SensorGenerator
{
    public class Sensor
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string IpAdress { get; set; }
        public static int PC { get; set; } = 1;

        public Sensor(string newIdentifier, string newName, string newType, int newValue, string newComment)
        {
            this.Identifier = newIdentifier;
            this.Name = newName;
            this.Type = newType;
            this.Value = newValue;
            this.Comment = newComment;
            this.Date = DateTime.Now.ToString();
            this.IpAdress = GetLocalIPAddress();
        }

        public static string GetLocalIPAddress()
        {
            return "192.168.1.1";
        }

        public static void SetPcUp()
        {
            PC += 1;
        }

        public void SetDateToday()
        {
            this.Date = DateTime.Now.ToString();
        }
    }
}
