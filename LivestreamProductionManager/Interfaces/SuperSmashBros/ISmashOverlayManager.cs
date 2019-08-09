using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.Interfaces.SuperSmashBros
{
    public interface ISmashOverlayManager
    {
        void UpdateSinglesOverlay(SinglesViewModel singlesViewModel);
        void UpdateDoublesOverlay(DoublesViewModel doublesViewModel);
        void UpdateCrewsOverlay(CrewsViewModel crewsViewModel);
        void UpdateSquadStrikeOverlay(SquadStrikeViewModel squadStrikeViewModel);
    }
}