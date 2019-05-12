namespace TradfriApi.Models
{
    public enum ApiPowerSource
    {
        DCPower = 0,
        InternalBattery = 1,
        ExternalBattery = 2,
        Battery = 3, //used by motion sensor
        POE = 4, //power over ethernet
        USB = 5,
        ACPower = 6,
        Solar = 7,
        Unknown_1 = 8,
        Unknown_2 = 9,
    }
}
