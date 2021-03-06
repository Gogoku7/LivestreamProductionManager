﻿using System.Collections.Generic;

namespace LivestreamProductionManager.Models.FightingGames.SuperSmashBros
{
    public class CrewCssModel
    {
        public string Name { get; set; }
        public string StocksLeft { get; set; }
        public string CharacterPath { get; set; }
        public string PortPath { get; set; }
        public string CountryPath { get; set; }
        public List<CrewPlayerCssModel> CrewPlayerCssModels { get; set; }

        public CrewCssModel()
        {
            CrewPlayerCssModels = new List<CrewPlayerCssModel>();
        }
    }
}