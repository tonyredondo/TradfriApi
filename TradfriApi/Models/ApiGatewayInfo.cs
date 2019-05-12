using System;

namespace TradfriApi.Models
{
    public class ApiGatewayInfo
    {
        public string NTP { get; set; }
        public string Firmware { get; set; }
        public long OtaUpdateState { get; set; }
        public long GatewayUpdateProgress { get; set; }
        public long CurrentTimeUnix { get; set; }
        public string CurrentTimeISO8601 { get; set; }
        public long CommissioningMode { get; set; }
        public long The9062 { get; set; }
        public long OtaType { get; set; }
        public DateTime FirstSetup { get; set; }
        public long GatewayTimeSource { get; set; }
        public long The9072 { get; set; }
        public long The9073 { get; set; }
        public long The9074 { get; set; }
        public long The9075 { get; set; }
        public long The9076 { get; set; }
        public long The9077 { get; set; }
        public long The9078 { get; set; }
        public long The9079 { get; set; }
        public long The9080 { get; set; }
        public string GatewayID { get; set; }
        public bool The9082 { get; set; }
        public string HomekitID { get; set; }
        public long The9092 { get; set; }
        public long The9093 { get; set; }
        public long The9106 { get; set; }
    }
}
