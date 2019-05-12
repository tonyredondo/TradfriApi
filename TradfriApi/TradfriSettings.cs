using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradfriApi
{
    public class TradfriSettings
    {
        public string ApplicationName { get; set; }
        public string ApplicationPSK { get; set; }
        public string GatewayName { get; set; }
        public string GatewayIp { get; set; }
        public string GatewayPSK { get; set; }
    }
}
