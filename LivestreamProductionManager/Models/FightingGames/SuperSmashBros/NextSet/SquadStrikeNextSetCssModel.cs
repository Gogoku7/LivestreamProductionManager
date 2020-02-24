namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet
{
    public class SquadStrikeNextSetCssModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }

        public SquadCssModel Squad1 { get; set; }
        public SquadCssModel Squad2 { get; set; }

        public SquadStrikeNextSetCssModel()
        {
            Squad1 = new SquadCssModel();
            Squad2 = new SquadCssModel();
        }
    }
}