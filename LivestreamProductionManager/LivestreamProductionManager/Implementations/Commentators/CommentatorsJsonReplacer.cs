using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.Models.Commentators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsJsonReplacer : ICommentatorsValuesReplacer
    {
        

        public string ReplaceValuesForCommentators(string fileTemplate, List<CommentatorsValuesModel> commentatorsValuesModels)
        {
            try
            {
                string fileContent = "";

                for (var i = 0; i < commentatorsValuesModels.Count(); i++)
                {
                    fileContent += commentatorsValuesModels[i].Name;
                    fileContent += commentatorsValuesModels[i].Twitter;
                }

                return fileTemplate.Replace("CONTENT", fileContent.Substring(0, fileContent.Length - 3));
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}