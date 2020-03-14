using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class SuperSmashBrosQueuBaseViewModel : TournamentViewModel
    {
        public int Index { get; set; }
        public List<CharacterViewModel> Characters { get; set; }
        public List<PortViewModel> Ports { get; set; }
        public List<CountryViewModel> Countries { get; set; }
    }
}