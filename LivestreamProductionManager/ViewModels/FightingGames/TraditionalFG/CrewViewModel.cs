using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG
{
    public class CrewViewModel
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public string Character { get; set; }
        public string Country { get; set; }
        public List<CrewPlayerViewModel> Players { get; set; }
    }
}