using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.TraditionalFG
{
    public class TraditionalFGCssFileWriter : ITraditionalFGFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ITraditionalFGValuesReplacer _traditionalFGTextReplacer = new TraditionalFGCssReplacer();

        public void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("TraditionalFG/TraditionalFGSinglesTemplate.css");
                var cssFileContent = _traditionalFGTextReplacer.ReplaceValuesForSingles(templateCssFile, singlesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("TraditionalFG/TraditionalFGCrewsTemplate.css");
                var cssFileContent = _traditionalFGTextReplacer.ReplaceValuesForCrews(templateCssFile, crewsCssModel);

                var file = new FileInfo(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"));
                file.Directory.Create();

                File.WriteAllText(file.FullName, cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void WriteSinglesNextSetFile(string pathToNextSetFormat, SinglesNextSetCssModel singlesNextSetCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("TraditionalFG/TraditionalFGSinglesNextSetTemplate.css");
                var cssFileContent = _traditionalFGTextReplacer.ReplaceValuesForSinglesNextSet(templateCssFile, singlesNextSetCssModel);

                var file = new FileInfo(HttpContext.Current.Server.MapPath(pathToNextSetFormat + "CSS/Content.css"));
                file.Directory.Create();

                File.WriteAllText(file.FullName, cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void WriteCrewsNextSetFile(string pathToNextSetFormat, CrewsNextSetCssModel crewsNextSetCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("TraditionalFG/TraditionalFGCrewsNextSetTemplate.css");
                var cssFileContent = _traditionalFGTextReplacer.ReplaceValuesForCrewsNextSet(templateCssFile, crewsNextSetCssModel);

                var file = new FileInfo(HttpContext.Current.Server.MapPath(pathToNextSetFormat + "CSS/Content.css"));
                file.Directory.Create();

                File.WriteAllText(file.FullName, cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void WriteJsonFile(string pathToFormat, List<SelectorValueModel> selectorValueModels)
        {
            throw new NotImplementedException();
        }
    }
}