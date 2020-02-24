using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashValuesReplacer
    {
        string ReplaceValuesForSingles(string fileTemplate, SinglesCssModel singlesCssModel);
        string ReplaceValuesForDoubles(string fileTemplate, DoublesCssModel doublesCssModel);
        string ReplaceValuesForCrews(string fileTemplate, CrewsCssModel crewsCssModel);
        string ReplaceValuesForSquadStrike(string fileTemplate, SquadStrikeCssModel squadStrikeCssModel);

        string ReplaceValuesForSinglesNextSet(string fileTemplate, SinglesNextSetCssModel singlesNextSetCssModel);
        string ReplaceValuesForDoublesNextSet(string fileTemplate, DoublesNextSetCssModel doublesNextSetCssModel);
        string ReplaceValuesForCrewsNextSet(string fileTemplate, CrewsNextSetCssModel crewsNextSetCssModel);
        string ReplaceValuesForSquadStrikeNextSet(string fileTemplate, SquadStrikeNextSetCssModel squadStrikeNextSetCssModel);
    }
}