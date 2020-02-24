namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet
{
    public class SinglesNextSetViewModel : PathsViewModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }
        public string PathToFormatNextSet { get; set; }
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
    }
}