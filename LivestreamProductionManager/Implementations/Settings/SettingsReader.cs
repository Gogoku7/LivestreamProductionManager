using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.Settings;
using Serilog;
using System;
using System.Linq;

namespace LivestreamProductionManager.Implementations.Settings
{
    public class SettingsReader : ISettingsReader
    {
        protected readonly IConfigReader _configReader = new JsonFileConfigReader();

        public string GetSettingValue(string pathToSettingsFile, string settingKey)
        {
            try
            {
                var settings = _configReader.GetSettings(pathToSettingsFile);
                return settings.First(s => s.SettingKey == settingKey).Value;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}