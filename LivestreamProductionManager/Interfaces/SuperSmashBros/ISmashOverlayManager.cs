using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashOverlayManager
    {
        void UpdateSinglesOverlay(SinglesViewModel singlesViewModel);
        void UpdateDoublesOverlay(DoublesViewModel doublesViewModel);
        void UpdateCrewsOverlay(CrewsViewModel crewsViewModel);
        void UpdateSquadStrikeOverlay(SquadStrikeViewModel squadStrikeViewModel);

        void UpdateSinglesNextSetOverlay(SinglesNextSetViewModel singlesNextSetViewModel);
        void UpdateDoublesNextSetOverlay(DoublesNextSetViewModel doublesNextSetViewModel);
        void UpdateCrewsNextSetOverlay(CrewsNextSetViewModel crewsNextSetViewModel);
        void UpdateSquadStrikeNextSetOverlay(SquadStrikeNextSetViewModel squadStrikeNextSetViewModel);
    }
}