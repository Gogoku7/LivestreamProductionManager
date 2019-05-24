using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashValuesReplacer
    {
        string ReplaceValuesForSingles(string fileTemplate, SinglesCssModel singlesCssModel);
        string ReplaceValuesForDoubles(string fileTemplate, DoublesCssModel doublesCssModel);
        string ReplaceValuesForCrews(string fileTemplate, CrewsCssModel crewsCssModel);
        string ReplaceValuesForSquadStrike(string fileTemplate, SquadStrikeCssModel squadStrikeCssModel);
    }
}