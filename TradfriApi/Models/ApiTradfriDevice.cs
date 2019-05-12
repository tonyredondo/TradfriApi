using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradfriApi.Models
{
    public class ApiTradfriDevice
    {
        public List<ApiRootSwitch> RootSwitch { get; set; }
        public ApiDeviceInfo Info { get; set; }
        public ApiDeviceType DeviceType { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public long ID { get; set; }
        public long ReachableState { get; set; }
        public DateTime LastSeen { get; set; }
        public long OtaUpdateState { get; set; }
        public List<ApiLightControl> LightControl { get; set; }
    }
}
