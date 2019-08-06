using LivestreamProductionManager.ViewModels.Settings;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Settings
{
    public interface ISettingsFileManager
    {
        void UpdateSettingsFile(string pathToSettingsFile, List<Setting> newsettings, List<Setting> settings);
    }
}