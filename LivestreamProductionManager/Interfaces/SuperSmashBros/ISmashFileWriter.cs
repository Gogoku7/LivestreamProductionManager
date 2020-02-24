using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashFileWriter
    {
        void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel);
        void WriteDoublesFile(string pathToFormat, DoublesCssModel doublesCssModel);
        void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel);
        void WriteSquadStrikeFile(string pathToFormat, SquadStrikeCssModel squadStrikeCssModel);
        

        void WriteSinglesNextSetFile(string pathToNextSetFormat, SinglesNextSetCssModel singlesNextSetCssModel);
        void WriteDoublesNextSetFile(string pathToNextSetFormat, DoublesNextSetCssModel doublesNextSetCssModel);
        void WriteCrewsNextSetFile(string pathToNextSetFormat, CrewsNextSetCssModel crewsNextSetCssModel);
        void WriteSquadStrikeNextSetFile(string pathToNextSetFormat, SquadStrikeNextSetCssModel squadStrikeNextSetCssModel);

        void WriteJsonFile(string pathToFormat, List<SelectorValueModel> selectorValueModels);
    }
}