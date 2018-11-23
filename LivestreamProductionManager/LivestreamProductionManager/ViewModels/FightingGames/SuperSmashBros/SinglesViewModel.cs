using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.ViewModels.SuperSmashBros
{
    public class SinglesViewModel : SuperSmashBrosBaseViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
    }
}