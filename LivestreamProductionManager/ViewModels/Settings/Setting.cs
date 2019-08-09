using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.Settings
{
    public class Setting
    {
        public string SettingKey { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public List<Option> Options { get; set; }

        public Setting()
        {

        }
    }
}