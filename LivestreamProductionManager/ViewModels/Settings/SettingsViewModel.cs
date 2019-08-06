using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.Settings
{
    public class SettingsViewModel
    {
        public string PathToSettingsFile { get; set; }
        public List<Setting> Settings { get; set; }

        public SettingsViewModel()
        {

        }

        public SettingsViewModel(string pathToSettingsFile, List<Setting> settings)
        {
            PathToSettingsFile = pathToSettingsFile;
            Settings = settings;
        }
    }
}