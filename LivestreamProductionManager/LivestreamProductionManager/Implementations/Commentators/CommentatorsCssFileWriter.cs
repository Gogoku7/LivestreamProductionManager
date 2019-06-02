using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.Models.Commentators;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsCssFileWriter : ICommentatorsFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ICommentatorsValuesReplacer _commentatorsValuesReplacer = new CommentatorsCssReplacer();

        public void WriteCommentatorsFile(string pathToGame, List<CommentatorsValuesModel> commentatorsValuesModels)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("Commentators/CommentatorsTemplate.css");
                var cssFileContent = _commentatorsValuesReplacer.ReplaceValuesForCommentators(templateCssFile, commentatorsValuesModels);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToGame + "Commentators/CSS/Content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
            
        }
    }
}