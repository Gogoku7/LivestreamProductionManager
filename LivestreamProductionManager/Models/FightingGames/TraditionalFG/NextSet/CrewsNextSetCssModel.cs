namespace LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet
{
    public class CrewsNextSetCssModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }

        public CrewCssModel Crew1 { get; set; }
        public CrewCssModel Crew2 { get; set; }

        public CrewsNextSetCssModel()
        {
            Crew1 = new CrewCssModel();
            Crew2 = new CrewCssModel();
        }
    }
}