namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet
{
    public class SquadStrikeNextSetViewModel : PathsViewModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }
        public string PathToFormatNextSet { get; set; }

        public SquadViewModel Squad1 { get; set; }
        public SquadViewModel Squad2 { get; set; }
    }
}