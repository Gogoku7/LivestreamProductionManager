using System.Collections.Generic;

namespace LivestreamProductionManager.Models.FightingGames.Skins
{
    public class SkinsConfig
    {
        public bool SupportsSkins { get; set; }
        public List<CharacterConfig> Characters { get; set; }
    }
}