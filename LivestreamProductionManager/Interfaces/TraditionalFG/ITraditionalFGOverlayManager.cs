using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG.NewSet;

namespace LivestreamProductionManager.Interfaces.TraditionalFG
{
    public interface ITraditionalFGOverlayManager
    {
        void UpdateSinglesOverlay(SinglesViewModel singlesViewModel);
        void UpdateCrewsOverlay(CrewsViewModel crewsViewModel);

        void UpdateSinglesNextSetOverlay(SinglesNextSetViewModel singlesNextSetViewModel);
        void UpdateCrewsNextSetOverlay(CrewsNextSetViewModel crewsNextSetViewModel);
    }
}