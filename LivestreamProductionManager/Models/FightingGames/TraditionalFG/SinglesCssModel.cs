using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LivestreamProductionManager.Models.FightingGames.TraditionalFG
{
    public class SinglesCssModel
    {
        public string Tournament { get; set; }
        public string Extra { get; set; }
        public string Round { get; set; }
        public string BestOf { get; set; }

        public PlayerCssModel Player1 { get; set; }
        public PlayerCssModel Player2 { get; set; }

        public SinglesCssModel()
        {
            Player1 = new PlayerCssModel();
            Player2 = new PlayerCssModel();
        }
    }
}