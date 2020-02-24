namespace LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet
{
    public class SinglesNextSetCssModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }

        public PlayerCssModel Player1 { get; set; }
        public PlayerCssModel Player2 { get; set; }

        public SinglesNextSetCssModel()
        {
            Player1 = new PlayerCssModel();
            Player2 = new PlayerCssModel();
        }
    }
}