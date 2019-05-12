using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri.Models;

namespace TradfriApi
{
    public static class MapModel
    {
        public static ApiTradfriDevice Map(TradfriDevice device)
        {
            return device != null ? new ApiTradfriDevice
            {
                CreatedAt = device.CreatedAt,
                DeviceType = (ApiDeviceType)device.DeviceType,
                ID = device.ID,
                Info = Map(device.Info),
                LastSeen = device.LastSeen,
                LightControl = device.LightControl?.Select(lc => Map(lc)).ToList(),
                Name = device.Name,
                OtaUpdateState = device.OtaUpdateState,
                ReachableState = device.ReachableState,
                RootSwitch = device.RootSwitch?.Select(rs => Map(rs)).ToList()
            } : null;
        }
        public static ApiDeviceInfo Map(DeviceInfo info)
        {
            return info != null ? new ApiDeviceInfo
            {
                Battery = info.Battery,
                DeviceType = info.DeviceType,
                FirmwareVersion = info.FirmwareVersion,
                Manufacturer = info.Manufacturer,
                PowerSource = (ApiPowerSource)info.PowerSource,
                Serial = info.Serial
            } : null;
        }
        public static ApiRootSwitch Map(RootSwitch rs)
        {
            return rs != null ? new ApiRootSwitch
            {
                RootSwitchID = rs.RootSwitchID
            } : null;
        }
        public static ApiLightControl Map(LightControl lc)
        {
            return lc != null ? new ApiLightControl
            {
                ColorHex = lc.ColorHex,
                ColorX = lc.ColorX,
                ColorY = lc.ColorY,
                Dimmer = lc.Dimmer,
                ID = lc.ID,
                Mireds = lc.Mireds,
                State = lc.State == Bool.True
            } : null;
        }
        public static ApiTradfriGroup Map(TradfriGroup group)
        {
            return group != null ? new ApiTradfriGroup
            {
                ActiveMood = group.ActiveMood,
                CreatedAt = group.CreatedAt,
                Devices = Map(group.Devices),
                ID = group.ID,
                LightDimmer = group.LightDimmer,
                LightState = group.LightState,
                Name = group.Name
            } : null;
        }
        public static ApiThe9018 Map(The9018 item)
        {
            return item != null ? new ApiThe9018
            {
                The15002 = Map(item.The15002)
            } : null;
        }
        public static ApiThe15002 Map(The15002 item)
        {
            return item != null ? new ApiThe15002
            {
                ID = item.ID
            } : null;
        }
        public static ApiGatewayInfo Map(GatewayInfo info)
        {
            return info != null ? new ApiGatewayInfo
            {
                NTP = info.NTP,
                Firmware = info.Firmware,
                OtaUpdateState = info.OtaUpdateState,
                GatewayUpdateProgress = info.GatewayUpdateProgress,
                CurrentTimeUnix = info.CurrentTimeUnix,
                CurrentTimeISO8601 = info.CurrentTimeISO8601,
                CommissioningMode = info.CommissioningMode,
                The9062 = info.The9062,
                OtaType = info.OtaType,
                FirstSetup = info.FirstSetup,
                GatewayTimeSource = info.GatewayTimeSource,
                The9072 = info.The9072,
                The9073 = info.The9073,
                The9074 = info.The9074,
                The9075 = info.The9075,
                The9076 = info.The9076,
                The9077 = info.The9077,
                The9078 = info.The9078,
                The9079 = info.The9079,
                The9080 = info.The9080,
                GatewayID = info.GatewayID,
                The9082 = info.The9082,
                HomekitID = info.HomekitID,
                The9092 = info.The9092,
                The9093 = info.The9093,
                The9106 = info.The9106
            } : null;
        }
        public static ApiTradfriMood Map(TradfriMood mood)
        {
            return mood != null ? new ApiTradfriMood
            {
                CreatedAt = mood.CreatedAt,
                GroupID = mood.GroupID,
                ID = mood.ID,
                MoodProperties = mood.MoodProperties?.Select(moodProp => Map(moodProp)).ToArray(),
                Name = mood.Name,
                The9057 = mood.The9057,
                The9068 = mood.The9068
            } : null;
        }
        public static ApiTradfriMoodProperties Map(TradfriMoodProperties moodProp)
        {
            return moodProp != null ? new ApiTradfriMoodProperties
            {
                ColorHex = moodProp.ColorHex,
                ColorHue = moodProp.ColorHue,
                ColorSaturation = moodProp.ColorSaturation,
                ColorX = moodProp.ColorX,
                ColorY = moodProp.ColorY,
                Dimmer = moodProp.Dimmer,
                ID = moodProp.ID,
                LightState = moodProp.LightState,
                Mireds = moodProp.Mireds
            } : null;
        }
        public static ApiTradfriSmartTask Map(TradfriSmartTask sTask)
        {
            return sTask != null ? new ApiTradfriSmartTask
            {
                ActionTurnOff = Map(sTask.ActionTurnOff),
                ActionTurnOn = Map(sTask.ActionTurnOn),
                CreatedAt = sTask.CreatedAt,
                ID = sTask.ID,
                LightState = sTask.LightState,
                RepeatDays = sTask.RepeatDays,
                TaskType = (ApiTradfriConstAttr)sTask.TaskType,
                TriggerTimeInterval = sTask.TriggerTimeInterval?.Select(tti => Map(tti))?.ToArray()
            } : null;
        }
        public static ApiTradfriAction Map(TradfriAction action)
        {
            return action != null ? new ApiTradfriAction
            {
                Devices = action.Devices?.Select(dev => Map(dev))?.ToArray(),
                LightState = action.LightState
            } : null;
        }
        public static ApiSmartTaskTrigger Map(SmartTaskTrigger tti)
        {
            return tti != null ? new ApiSmartTaskTrigger
            {
                EndHour = tti.EndHour,
                EndMin = tti.EndMin,
                StartHour = tti.StartHour,
                StartMin = tti.StartMin
            } : null;
        }
    }
}
