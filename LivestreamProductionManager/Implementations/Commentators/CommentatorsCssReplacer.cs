using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.Models.Commentators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsCssReplacer : ICommentatorsValuesReplacer
    {
        public string ReplaceValuesForCommentators(string fileTemplate, List<CommentatorsValuesModel> commentatorsValuesModels)
        {
            try
            {
                var commentatorNames = "";
                var commentatorTwitters = "";

                for (var i = 0; i < commentatorsValuesModels.Count(); i++)
                {
                    commentatorNames += commentatorsValuesModels[i].Name + "\r\n";
                    commentatorTwitters += commentatorsValuesModels[i].Twitter + "\r\n";
                }

                fileTemplate = fileTemplate.Replace("CommentatorNamesPLACEHOLDER", commentatorNames);
                fileTemplate = fileTemplate.Replace("CommentatorTwittersPLACEHOLDER", commentatorTwitters);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}