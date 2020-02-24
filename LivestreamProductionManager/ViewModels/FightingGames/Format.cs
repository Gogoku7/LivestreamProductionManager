using System.Web;
using System.Web.Mvc;

namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class Format
    {
        public string FormatName { get; set; }
        public string FORMAT { get; set; }

        /// <summary>
        /// In order for this to work as intended, the "Url" properties in FormatsConfig.json need to be EXACTLY formatted as "/{Controller}/{Action}" or "{Controller}/{Action}". Examples: "/SuperSmashBros/GetManageCompetitors" and "SuperSmashBros/GetManageCompetitors"
        /// </summary>
        private string _url;
        /// <summary>
        /// In order for this to work as intended, the "Url" properties in FormatsConfig.json need to be EXACTLY formatted as "/{Controller}/{Action}" or "{Controller}/{Action}". Examples: "/SuperSmashBros/GetManageCompetitors" and "SuperSmashBros/GetManageCompetitors"
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                if (value.StartsWith("/"))
                {
                    _url = new UrlHelper(HttpContext.Current.Request.RequestContext).Action(value.Split('/')[2], value.Split('/')[1]);
                }
                else
                {
                    _url = new UrlHelper(HttpContext.Current.Request.RequestContext).Action(value.Split('/')[1], value.Split('/')[0]);
                }
            } 
        }

        /// <summary>
        /// In order for this to work as intended, the "PathToFormat" properties in FormatsConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the format folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/Singles/" and "~/FightingGames/SuperSmashBros/Ultimate/Doubles/"
        /// </summary>
        private string _pathToFormat;

        /// <summary>
        /// In order for this to work as intended, the "PathToFormat" properties in FormatsConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the format folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/Singles/" and "~/FightingGames/SuperSmashBros/Ultimate/Doubles/"
        /// </summary>
        public string PathToFormat
        {
            get
            {
                return _pathToFormat;
            }
            set
            {
                if (value.StartsWith("~/"))
                {
                    _pathToFormat = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(value);
                }
                else if (value.StartsWith("/"))
                {
                    _pathToFormat = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~{value}");
                }
                else
                {
                    _pathToFormat = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~/{value}");
                }
            }
        }

        /// <summary>
        /// In order for this to work as intended, the "PathToNextSet" properties in FormatsConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the format folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/SinglesNextSet/" and "~/FightingGames/SuperSmashBros/Ultimate/DoublesNextSet/"
        /// </summary>
        private string _pathToNextSet;

        /// <summary>
        /// In order for this to work as intended, the "PathToNextSet" properties in FormatsConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the format folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/SinglesNextSet/" and "~/FightingGames/SuperSmashBros/Ultimate/DoublesNextSet/"
        /// </summary>
        public string PathToNextSet
        {
            get
            {
                return _pathToNextSet;
            }
            set
            {
                if (value.StartsWith("~/"))
                {
                    _pathToNextSet = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(value);
                }
                else if (value.StartsWith("/"))
                {
                    _pathToNextSet = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~{value}");
                }
                else
                {
                    _pathToNextSet = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~/{value}");
                }
            }
        }
    }
}