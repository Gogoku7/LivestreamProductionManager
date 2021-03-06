﻿namespace LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG.NewSet
{
    public class CrewsNextSetViewModel : PathsViewModel
    {
        public string Round { get; set; }
        public string BestOf { get; set; }
        public string PathToFormatNextSet { get; set; }

        public CrewViewModel Crew1 { get; set; }
        public CrewViewModel Crew2 { get; set; }
    }
}