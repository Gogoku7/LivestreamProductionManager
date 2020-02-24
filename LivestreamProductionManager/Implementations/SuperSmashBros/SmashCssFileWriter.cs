using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashCssFileWriter : ISmashFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ISmashValuesReplacer _smashTextReplacer = new SmashCssReplacer();

        public void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSinglesTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForSingles(templateCssFile, singlesCssModel);

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

        public void WriteDoublesFile(string pathToFormat, DoublesCssModel doublesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosDoublesTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForDoubles(templateCssFile, doublesCssModel);

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

        public void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosCrewsTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForCrews(templateCssFile, crewsCssModel);

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

        public void WriteSquadStrikeFile(string pathToFormat, SquadStrikeCssModel squadStrikeCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSquadStrikeTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForSquadStrike(templateCssFile, squadStrikeCssModel);

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
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSinglesNextSetTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForSinglesNextSet(templateCssFile, singlesNextSetCssModel);

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

        public void WriteDoublesNextSetFile(string pathToNextSetFormat, DoublesNextSetCssModel doublesNextSetCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosDoublesNextSetTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForDoublesNextSet(templateCssFile, doublesNextSetCssModel);

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
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosCrewsNextSetTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForCrewsNextSet(templateCssFile, crewsNextSetCssModel);

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

        public void WriteSquadStrikeNextSetFile(string pathToNextSetFormat, SquadStrikeNextSetCssModel squadStrikeNextSetCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSquadStrikeNextSetTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForSquadStrikeNextSet(templateCssFile, squadStrikeNextSetCssModel);

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