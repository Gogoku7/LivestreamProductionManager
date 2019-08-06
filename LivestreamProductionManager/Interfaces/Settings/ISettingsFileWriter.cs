using LivestreamProductionManager.ViewModels.Settings;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Settings
{
    public interface ISettingsFileWriter
    {
        void SettingsFile(string pathToSettingsFile, List<Setting> updatedSettings);
    }
}