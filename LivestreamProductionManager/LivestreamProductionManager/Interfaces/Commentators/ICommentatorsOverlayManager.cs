using LivestreamProductionManager.ViewModels.Commentators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsOverlayManager
    {
        void UpdateCommentatorsOverlay(string pathToGame, List<CommentatorViewModel> commentatorViewModels);
    }
}
