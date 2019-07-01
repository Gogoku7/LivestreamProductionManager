using System.Web;
using System.Web.Mvc;

namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class Series
    {
        public string SeriesName { get; set; }
        public string SERIES { get; set; }

        /// <summary>
        /// In order for this to work as intended, the "PathToSeries" properties in SeriesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the series folder}", Examples: "~/FightingGames/SuperSmashBros/" and "~/FightingGames/StreetFighter/"
        /// </summary>
        private string _pathToSeries;

        /// <summary>
        /// In order for this to work as intended, the "PathToSeries" properties in SeriesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the series folder}", Examples: "~/FightingGames/SuperSmashBros/" and "~/FightingGames/StreetFighter/"
        /// </summary>
        public string PathToSeries
        {
            get
            {
                return _pathToSeries;
            }
            set
            {
                if (value.StartsWith("~/"))
                {
                    _pathToSeries = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(value);
                }
                else if (value.StartsWith("/"))
                {
                    _pathToSeries = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~{value}");
                }
                else
                {
                    _pathToSeries = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~/{value}");
                }
            }
        }
    }
}