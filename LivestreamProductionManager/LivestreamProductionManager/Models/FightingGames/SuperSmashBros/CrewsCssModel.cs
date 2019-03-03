namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros
{
    public class CrewsCssModel
    {
        public string Tournament { get; set; }
        public string Extra { get; set; }
        public string Round { get; set; }
        public string BestOf { get; set; }

        public CrewCssModel Crew1 { get; set; }
        public CrewCssModel Crew2 { get; set; }

        public CrewsCssModel()
        {
            Crew1 = new CrewCssModel();
            Crew2 = new CrewCssModel();
        }
    }
}