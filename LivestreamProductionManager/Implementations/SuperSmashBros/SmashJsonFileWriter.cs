using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using Serilog;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashJsonFileWriter : ISmashFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/JsonTemplates/");
        private readonly ISmashValuesReplacer _smashTextReplacer = new SmashJsonReplacer();

        public void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            try
            {
                var templateJsonFile = _templateFileReader.ReadTemplateFile("ContentTemplate.json");
                var jsonFileContent = _smashTextReplacer.ReplaceValuesForSingles(templateJsonFile, singlesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json"), jsonFileContent);
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
                var templateJsonFile = _templateFileReader.ReadTemplateFile("ContentTemplate.json");
                var jsonFileContent = _smashTextReplacer.ReplaceValuesForDoubles(templateJsonFile, doublesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json"), jsonFileContent);
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
                var templateJsonFile = _templateFileReader.ReadTemplateFile("ContentTemplate.json");
                var jsonFileContent = _smashTextReplacer.ReplaceValuesForCrews(templateJsonFile, crewsCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json"), jsonFileContent);
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
                var templateJsonFile = _templateFileReader.ReadTemplateFile("ContentTemplate.json");
                var jsonFileContent = _smashTextReplacer.ReplaceValuesForSquadStrike(templateJsonFile, squadStrikeCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json"), jsonFileContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}