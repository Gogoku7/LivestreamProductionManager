﻿using LivestreamProductionManager.ViewModels.Commentators;
using LivestreamProductionManager.ViewModels.FightingGames;
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
                if (commentatorViewModels == null)
                {
                    throw new ArgumentException("variable CommentatorViewModels was null, this is a bug if the commentators form is not empty.");
                }

                //Save files

                return SuccessSnackbar("Successfully saved commentator files");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ErrorSnackbar(ex, "Something went wrong while saving commentator files, see the console for details");
            }
        }
    }
}