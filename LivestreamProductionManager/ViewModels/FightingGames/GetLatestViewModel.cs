using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class GetLatestViewModel
    {
        public bool Success { get; set; }
        public List<SelectorValueViewModel> Data { get; set; }

        public GetLatestViewModel(bool success, List<SelectorValueViewModel> data)
        {
            Success = success;
            Data = data;
        }
    }
}