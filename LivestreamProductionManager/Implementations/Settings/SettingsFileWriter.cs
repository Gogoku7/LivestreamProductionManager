﻿using LivestreamProductionManager.Interfaces.Settings;
using LivestreamProductionManager.ViewModels.Settings;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.Settings
{
    public class SettingsFileWriter : ISettingsFileWriter
    {
        public void SettingsFile(string pathToSettingsFile, List<Setting> updatedSettings)
        {
            try
            {
                var file = new FileInfo(HttpContext.Current.Server.MapPath(pathToSettingsFile));
                file.Directory.Create();

                File.WriteAllText(file.FullName, JsonConvert.SerializeObject(updatedSettings));

                //File.WriteAllText(HttpContext.Current.Server.MapPath(pathToSettingsFile), JsonConvert.SerializeObject(updatedSettings));
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}