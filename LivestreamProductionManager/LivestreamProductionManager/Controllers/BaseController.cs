using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Interfaces;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfigReader _configReader = new JsonFileConfigReader();
    }
}