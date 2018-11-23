using System;
using System.IO;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class FightingGamesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fight Games";

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
                Console.WriteLine(ex);
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
                Console.WriteLine(ex);
                throw;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}