using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Interfaces;
using Serilog;
using System;
using System.IO;
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

        public JsonResult GetSeries()
        {
            try
            {
                var series = _configReader.GetSeries();

                return Json(series, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public JsonResult GetGames(string pathToSeries)
        {
            try
            {
                var games = _configReader.GetGames(pathToSeries);

                return Json(games, JsonRequestBehavior.AllowGet);
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

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
                throw;
            }
        }

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
    }
}