﻿using System.Collections.Generic;

namespace LivestreamProductionManager.Models.FightingGames.TraditionalFG
{
    public class CrewCssModel
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public string CharacterPath { get; set; }
        public string CountryPath { get; set; }
        public List<CrewPlayerCssModel> CrewPlayerCssModels { get; set; }

        public CrewCssModel()
        {
            CrewPlayerCssModels = new List<CrewPlayerCssModel>();
        }
    }
}