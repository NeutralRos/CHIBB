using System;
using System.Collections.Generic;

namespace CHIBB
{
    public partial class Sensorvalues
    {
        public int Valuekey { get; set; }
        public string Identifier { get; set; }
        public int? Sensordata { get; set; }
        public string Datadate { get; set; }
        public string Ipadress { get; set; }
        public virtual Sensors IdentifierNavigation { get; set; }
    }
}
