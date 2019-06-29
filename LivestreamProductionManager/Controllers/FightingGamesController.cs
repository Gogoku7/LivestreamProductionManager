using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.ViewModels.FightingGames;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class FightingGamesController : BaseController
    {
        private readonly IFileReader _fileReader = new FileReader();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetSeries()
        {
            try
            {
                var series = _configReader.GetSeries();

                return Json(series, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong with retrieving series.", ex);
            }
        }

        [HttpPost]
        public JsonResult GetGames(string pathToSeries)
        {
            try
            {
                var games = _configReader.GetGames(pathToSeries);

                return Json(games, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong with retrieving games.", ex);
            }
        }

        [HttpPost]
        public JsonResult GetFormats(string pathToGame)
        {
            try
            {
                var formats = _configReader.GetFormats(pathToGame);

                return Json(formats, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong with retrieving formats.", ex);
            }
        }

        [HttpPost]
        public string GetCssFileContent(string pathToFormat)
        {
            try
            {
                return _fileReader.ReadCssFile(pathToFormat);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public string GetJsonFileContent(string pathToFormat)
        {
            try
            {
                return _fileReader.ReadJsonFile(pathToFormat);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public JsonResult GetLatestValues(string pathToFormat)
        {
            try
            {
                var json = _fileReader.ReadJsonFile(pathToFormat);

                return Json(new GetLatestViewModel(true, JsonConvert.DeserializeObject<List<SelectorValueViewModel>>(json)), JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong with retrieving the latest values.", ex);
            }
        }

        [HttpPost]
        public JsonResult GetReadMe(string pathToFormat)
        {
            try
            {
                var readMeJsonContent = _fileReader.ReadReadMeFile(pathToFormat);

                return Json(JsonConvert.DeserializeObject<ReadMe>(readMeJsonContent), JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong with retrieving the ReadMe content.", ex);
            }
        }
    }
}