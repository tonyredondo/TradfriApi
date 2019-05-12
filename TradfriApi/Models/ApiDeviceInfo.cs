namespace TradfriApi.Models
{
    public class ApiDeviceInfo
    {
        public string Manufacturer { get; set; }
        public string DeviceType { get; set; }
        public string Serial { get; set; }
        public string FirmwareVersion { get; set; }
        public ApiPowerSource PowerSource { get; set; }
        public long Battery { get; set; }
    }
}
