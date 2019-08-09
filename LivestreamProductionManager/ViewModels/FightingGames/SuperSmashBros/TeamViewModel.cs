using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public List<PlayerViewModel> Players { get; set; }
    }
}