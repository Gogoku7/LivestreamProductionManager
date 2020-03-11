using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG
{
    public class TraditionalFGQueuBaseViewModel : TournamentViewModel
    {
        public int Index { get; set; }
        public List<CharacterViewModel> Characters { get; set; }
        public List<CountryViewModel> Countries { get; set; }
    }
}