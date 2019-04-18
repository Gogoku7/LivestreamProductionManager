using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.ViewModels.SuperSmashBros
{
    public class SinglesViewModel : TournamentViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
    }
}