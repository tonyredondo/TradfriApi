namespace TradfriApi.Models
{
    public enum ApiTradfriConstAttr
    {
        Auth = 9063,
        Psk = 9091,
        Identity = 9090,

        ApplicationType = 5750,

        CreatedAt = 9002,

        CommissioningMode = 9061,

        CurrentTimeUnix = 9061,
        CurrentTimeISO8601 = 9060,

        DeviceInfo = 3,

        GatewayTimeSource = 9071,
        GatewayUpdateProgress = 9055,

        HomekitID = 9083,

        ID = 9003,
        LastSeen = 9020,
        LightControl = 3311,

        Name = 9001,
        NTP = 9023,
        FirmwareVersion = 9029,
        FirstSetup = 9069,

        GatewayInfo = 15012,
        GatewayID = 9081,
        GatewayReboot = 9030,
        GatewayFactoryDefaults = 9031, //gw to factory defaults
        GatewayFactoryDefaultsMinMaxMSR = 5605,

        LightState = 5850, // 0 or 1
        LightDimmer = 5851, // Dimmer, not following spec: 0..255
        LightColorHex = 5706, // string representing a value in hex
        LightColorX = 5709,
        LightColorY = 5710,
        LightColorSaturation = 5707, //guess
        LightColorHue = 5708, //guess
        LightMireds = 5711,

        MasterTokenTag = 9036,

        Mood = 9039,

        OtaType = 9066,
        OtaUpdateState = 9054,
        OtaUpdate = 9037,

        ReachableState = 9019,

        RepeatDays = 9041,

        Sensor = 3300,
        SensorMinRangeValue = 5603,
        SensorMaxRangeValue = 5604,
        SensorMinMeasuredValue = 5601,
        SensorMaxMeasuredValue = 5602,
        SensorType = 5751,
        SensorUnit = 5701,
        SensorValue = 5700,

        StartAction = 9042, // array

        SmartTaskType = 9040, // 4 = transition | 1 = not home | 2 = on/off
        SmartTaskNotAtHome = 1,
        SmartTaskLightsOff = 2,
        SmartTaskWakeUp = 4,

        SmartTaskTriggerTimeInterval = 9044,
        SmartTaskTriggerTimeStartHour = 9046,
        SmartTaskTriggerTimeStartMin = 9047,

        SwitchPlug = 3312,
        SwitchPowerFactor = 5820,

        TransiotionTime = 5712

    }
}
