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
        public PartialViewResult GetCommentatorRow(int id)
        {
            return PartialView("CommentatorRow", id);
        }

        [HttpPost]
        public JsonResult UpdateCommentators(List<CommentatorViewModel> commentatorViewModels)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(commentatorViewModels) }");

                if (commentatorViewModels == null)
                {
                    throw new ArgumentException("variable CommentatorViewModels was null, this is a bug if the commentators form is not empty.");
                }

                //Save files

                return SuccessSnackbar("Successfully saved commentator files.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return ErrorSnackbar(ex, "Something went wrong while saving commentator files, see the console for details.");
            }
        }
    }
}