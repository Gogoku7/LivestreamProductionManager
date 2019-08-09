using System.Web.Http;

namespace LivestreamProductionManager.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "SocketApi",
                routeTemplate: "WebSocket/{controller}"
            );
        }
    }
}