using System.Collections.Generic;

namespace LivestreamProductionManager.Models.FightingGames.TraditionalFG
{
    public class CrewCssModel
    {
        public string Name { get; set; }
        public string StocksLeft { get; set; }
        public string CharacterPath { get; set; }
        public List<CrewPlayerCssModel> CrewPlayerCssModels { get; set; }

        public CrewCssModel()
        {
            CrewPlayerCssModels = new List<CrewPlayerCssModel>();
        }
    }
}