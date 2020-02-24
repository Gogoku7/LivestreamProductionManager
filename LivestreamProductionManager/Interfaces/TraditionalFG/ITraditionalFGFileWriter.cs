using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.TraditionalFG
{
    public interface ITraditionalFGFileWriter
    {
        void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel);
        void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel);
        void WriteSinglesNextSetFile(string pathToNextSetFormat, SinglesNextSetCssModel singlesNextSetCssModel);
        void WriteCrewsNextSetFile(string pathToNextSetFormat, CrewsNextSetCssModel crewsNextSetCssModel);

        void WriteJsonFile(string pathToFormat, List<SelectorValueModel> selectorValueModels);
    }
}