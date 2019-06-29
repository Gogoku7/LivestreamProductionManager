using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class SquadViewModel
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public string Port { get; set; }
        public List<SquadPlayerViewModel> Players { get; set; }
    }
}