using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG
{
    public class TraditionalFGBaseViewModel : TournamentViewModel
    {
        public List<CharacterViewModel> Characters { get; set; }
        public List<CountryViewModel> Countries { get; set; }
    }
}