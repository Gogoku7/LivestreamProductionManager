namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet
{
    public class DoublesNextSetViewModel : PathsViewModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }
        public string PathToFormatNextSet { get; set; }
        public TeamViewModel Team1 { get; set; }
        public TeamViewModel Team2 { get; set; }
    }
}