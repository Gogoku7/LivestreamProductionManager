using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashFileWriter
    {
        void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel);

        void WriteDoublesFile(string pathToFormat, DoublesCssModel doublesCssModel);

        void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel);

        void WriteSquadStrikeFile(string pathToFormat, SquadStrikeCssModel squadStrikeCssModel);
    }
}