using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.ViewModels.Commentators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsCssOverlayManager : ICommentatorsOverlayManager
    {
        public void UpdateSinglesOverlay(string pathToGame, List<CommentatorViewModel> commentatorViewModels)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}