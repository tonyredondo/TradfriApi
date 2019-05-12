using System;

namespace TradfriApi.Models
{
    public class ApiTradfriSmartTask
    {
        public long LightState { get; set; }
        public DateTime CreatedAt { get; set; }
        public long ID { get; set; }
        public ApiTradfriConstAttr TaskType { get; set; }
        public long RepeatDays { get; set; }
        public ApiTradfriAction ActionTurnOn { get; set; }
        public ApiTradfriAction ActionTurnOff { get; set; }
        public ApiSmartTaskTrigger[] TriggerTimeInterval { get; set; }
    }
}
