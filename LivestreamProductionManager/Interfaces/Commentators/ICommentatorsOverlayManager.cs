using LivestreamProductionManager.ViewModels.Commentators;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsOverlayManager
    {
        void UpdateCommentatorsOverlay(string pathToCommentators, List<CommentatorViewModel> commentatorViewModels);
    }
}
