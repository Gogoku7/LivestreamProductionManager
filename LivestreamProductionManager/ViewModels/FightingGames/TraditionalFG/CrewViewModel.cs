using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG
{
    public class CrewViewModel
    {
        public string Name { get; set; }
        public string StocksLeft { get; set; }
        public string Character { get; set; }
        public List<CrewPlayerViewModel> Players { get; set; }
    }
}