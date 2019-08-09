using LivestreamProductionManager.Interfaces.Settings;
using LivestreamProductionManager.ViewModels.Settings;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivestreamProductionManager.Implementations.Settings
{
    public class SettingsFileManager : ISettingsFileManager
    {
        private readonly ISettingsFileWriter _settingsFileWriter = new SettingsFileWriter();

        public void UpdateSettingsFile(string pathToSettingsFile, List<Setting> newsettings, List<Setting> settings)
        {
            try
            {
                foreach (var newSetting in newsettings)
                {
                    var setting = settings.FirstOrDefault(s => s.SettingKey == newSetting.SettingKey);
                    if (setting != null)
                    {
                        setting.Value = newSetting.Value;
                    }
                }

                _settingsFileWriter.SettingsFile(pathToSettingsFile, settings);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}