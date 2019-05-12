using System;

namespace TradfriApi.Models
{
    public class ApiTradfriGroup
    {
        public long LightState { get; set; }
        public long LightDimmer { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public long ID { get; set; }
        public ApiThe9018 Devices { get; set; }
        public long ActiveMood { get; set; }
    }
}
