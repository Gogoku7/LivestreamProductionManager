using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class SuperSmashBrosBaseViewModel : TournamentViewModel
    {
        public List<CharacterViewModel> Characters { get; set; }
        public List<PortViewModel> Ports { get; set; }
        public List<CountryViewModel> Countries { get; set; }
    }
}