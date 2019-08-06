using LivestreamProductionManager.Implementations.Settings;
using LivestreamProductionManager.Interfaces.Settings;
using LivestreamProductionManager.ViewModels.Settings;
using Serilog;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class SettingsController : BaseController
    {
        ISettingsFileManager _settingsFileManager = new SettingsFileManager();

        [HttpPost]
        public ActionResult GetGeneralSettingsPartialView(string pathToSettingsFile)
        {
            try
            {
                var settingsViewModel = new SettingsViewModel(pathToSettingsFile, _configReader.GetSettings(pathToSettingsFile));

                return PartialView("~/Views/Shared/_GeneralSettingsPartialView.cshtml", settingsViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult UpdateSettings(SettingsViewModel settingsViewModel)
        {
            try
            {
                var settings = _configReader.GetSettings(settingsViewModel.PathToSettingsFile);

                _settingsFileManager.UpdateSettingsFile(settingsViewModel.PathToSettingsFile, settingsViewModel.Settings, settings);

                return RedirectToAction("Index", "FightingGames");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}