using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet;

namespace LivestreamProductionManager.Interfaces.TraditionalFG
{
    public interface ITraditionalFGValuesReplacer
    {
        string ReplaceValuesForSingles(string fileTemplate, SinglesCssModel singlesCssModel);
        string ReplaceValuesForCrews(string fileTemplate, CrewsCssModel crewsCssModel);

        string ReplaceValuesForSinglesNextSet(string fileTemplate, SinglesNextSetCssModel singlesNextSetCssModel);
        string ReplaceValuesForCrewsNextSet(string fileTemplate, CrewsNextSetCssModel crewsNextSetCssModel);
    }
}