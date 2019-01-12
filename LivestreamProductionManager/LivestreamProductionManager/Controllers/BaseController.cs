using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.ViewModels.FightingGames;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfigReader _configReader = new JsonFileConfigReader();

        public JsonResult SuccessSnackbar(string message)
        {
            return Json(new SnackbarViewModel(true, message), JsonRequestBehavior.DenyGet);
        }

        public JsonResult ErrorSnackbar(Exception ex, string message)
        {
            Console.WriteLine(ex);
            return Json(new SnackbarViewModel(false, message, ex.Message), JsonRequestBehavior.DenyGet);
        }
    }
}