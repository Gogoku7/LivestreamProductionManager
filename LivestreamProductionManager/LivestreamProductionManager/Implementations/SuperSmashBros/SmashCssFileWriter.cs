using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using Serilog;
using System;
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

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
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
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosCrewsTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceValuesForCrews(templateCssFile, crewsCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
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

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}