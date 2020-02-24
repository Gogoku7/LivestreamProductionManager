namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet
{
    public class DoublesNextSetCssModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }

        public TeamCssModel Team1 { get; set; }
        public TeamCssModel Team2 { get; set; }

        public DoublesNextSetCssModel()
        {
            Team1 = new TeamCssModel();
            Team2 = new TeamCssModel();
        }
    }
}