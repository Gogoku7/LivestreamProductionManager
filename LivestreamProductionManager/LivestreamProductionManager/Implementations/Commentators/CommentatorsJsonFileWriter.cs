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
    public class CommentatorsJsonFileWriter : ICommentatorsFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/JsonTemplates/");
        private readonly ICommentatorsValuesReplacer _commentatorsValuesReplacer = new CommentatorsJsonReplacer();

        public void WriteCommentatorsFile(string pathToGame, List<CommentatorsValuesModel> commentatorsValuesModels)
        {
            try
            {
                var templateJsonFile = _templateFileReader.ReadTemplateFile("ContentTemplate.json");
                var jsonFileContent = _commentatorsValuesReplacer.ReplaceValuesForCommentators(templateJsonFile, commentatorsValuesModels);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToGame + "Commentators/JSON/Content.json"), jsonFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }   
        }
    }
}