using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class CrewViewModel
    {
        public string Name { get; set; }
        public string StocksLeft { get; set; }
        public string Character { get; set; }
        public string Port { get; set; }
        public List<CrewPlayerViewModel> Players { get; set; }
    }
}