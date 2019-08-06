namespace LivestreamProductionManager.Interfaces.Settings
{
    public interface ISettingsReader
    {
        string GetSettingValue(string pathToSettingsFile, string settingKey);
    }
}