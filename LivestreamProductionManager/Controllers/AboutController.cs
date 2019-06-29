using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Version()
        {
            return View();
        }
    }
}