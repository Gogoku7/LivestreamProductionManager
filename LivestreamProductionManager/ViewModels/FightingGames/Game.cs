using System.Web;
using System.Web.Mvc;

namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class Game
    {
        public string GameName { get; set; }
        public string GAME { get; set; }

        /// <summary>
        /// In order for this to work as intended, the "PathToGame" properties in GamesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the game folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/" and "~/FightingGames/SuperSmashBros/Ultimate/"
        /// </summary>
        private string _pathToGame;

        /// <summary>
        /// In order for this to work as intended, the "PathToGame" properties in GamesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the game folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/" and "~/FightingGames/SuperSmashBros/Ultimate/"
        /// </summary>
        public string PathToGame
        {
            get
            {
                return _pathToGame;
            }
            set
            {
                if (value.StartsWith("~/"))
                {
                    _pathToGame = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(value);
                }
                else if (value.StartsWith("/"))
                {
                    _pathToGame = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~{value}");
                }
                else
                {
                    _pathToGame = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~/{value}");
                }
            }
        }

        /// <summary>
        /// In order for this to work as intended, the "PathToCommentators" properties in GamesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the commentators folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/Commentators" and "~/FightingGames/SuperSmashBros/Ultimate/Commentators"
        /// </summary>
        private string _pathToCommentators;

        /// <summary>
        /// In order for this to work as intended, the "PathToCommentators" properties in GamesConfig.json need to be EXACTLY formatted as "~/{Path from the root folder of the application up until the commentators folder}", Examples: "~/FightingGames/SuperSmashBros/Melee/Commentators" and "~/FightingGames/SuperSmashBros/Ultimate/Commentators"
        /// </summary>
        public string PathToCommentators
        {
            get
            {
                return _pathToCommentators;
            }
            set
            {
                if (value.StartsWith("~/"))
                {
                    _pathToCommentators = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(value);
                }
                else if (value.StartsWith("/"))
                {
                    _pathToCommentators = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~{value}");
                }
                else
                {
                    _pathToCommentators = new UrlHelper(HttpContext.Current.Request.RequestContext).Content($"~/{value}");
                }
            }
        }
    }
}