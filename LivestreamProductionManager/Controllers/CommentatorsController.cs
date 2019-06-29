using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Implementations.Commentators;
using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.ViewModels.Commentators;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class CommentatorsController : BaseController
    {
        private readonly ICommentatorsOverlayManager _commentatorsCssOverlayManager = new CommentatorsCssOverlayManager();
        private readonly ICommentatorsOverlayManager _commentatorsJsonOverlayManager = new CommentatorsJsonOverlayManager();
        private readonly IFileReader _fileReader = new FileReader();

        [HttpPost]
        public PartialViewResult GetCommentatorRow(int index)
        {
            return PartialView("CommentatorRow", index);
        }

        [HttpPost]
        public JsonResult UpdateCommentators(string pathToGame, List<CommentatorViewModel> commentatorViewModels)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(commentatorViewModels) }");

                if (commentatorViewModels == null)
                {
                    throw new ArgumentException("variable CommentatorViewModels was null, this is a bug if the commentators form is not empty.");
                }

                _commentatorsCssOverlayManager.UpdateCommentatorsOverlay(pathToGame, commentatorViewModels);
                _commentatorsJsonOverlayManager.UpdateCommentatorsOverlay(pathToGame, commentatorViewModels);

                return SuccessSnackbar("Successfully saved commentator files.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar("Something went wrong while saving commentator files, see the console for details.", ex);
            }
        }

        [HttpPost]
        public string GetCssFileContent(string pathToGame)
        {
            try
            {
                return _fileReader.ReadCssFile(pathToGame + "Commentators/");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public string GetJsonFileContent(string pathToGame)
        {
            try
            {
                return _fileReader.ReadJsonFile(pathToGame + "Commentators/");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}