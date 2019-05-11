namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros
{
    public class SquadStrikeCssModel
    {
        public string Tournament { get; set; }
        public string Extra { get; set; }
        public string Round { get; set; }
        public string BestOf { get; set; }

        public SquadCssModel Squad1 { get; set; }
        public SquadCssModel Squad2 { get; set; }

        public SquadStrikeCssModel()
        {
            Squad1 = new SquadCssModel();
            Squad2 = new SquadCssModel();
        }
    }
}