using System;
using System.Collections.Generic;

namespace CHIBB
{
    public partial class Sensors
    {
        public Sensors()
        {
            Sensorvalues = new HashSet<Sensorvalues>();
        }

        public string Identifier { get; set; }
        public string Sensorname { get; set; }
        public string Sensortype { get; set; }
        public string Sensorcomment { get; set; }

        public virtual ICollection<Sensorvalues> Sensorvalues { get; set; }
    }
}
