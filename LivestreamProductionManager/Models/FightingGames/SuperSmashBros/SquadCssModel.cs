using System.Collections.Generic;

namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros
{
    public class SquadCssModel
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public string PortPath { get; set; }
        public string CountryPath { get; set; }
        public List<SquadPlayerCssModel> SquadPlayerCssModels { get; set; }

        public SquadCssModel()
        {
            SquadPlayerCssModels = new List<SquadPlayerCssModel>();
        }
    }
}