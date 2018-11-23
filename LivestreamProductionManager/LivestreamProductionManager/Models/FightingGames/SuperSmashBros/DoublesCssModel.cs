namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros
{
    public class DoublesCssModel
    {
        public string Tournament { get; set; }
        public string Extra { get; set; }
        public string Round { get; set; }
        public string BestOf { get; set; }

        public TeamCssModel Team1 { get; set; }
        public TeamCssModel Team2 { get; set; }

        public DoublesCssModel()
        {
            Team1 = new TeamCssModel();
            Team2 = new TeamCssModel();
        }
    }
}