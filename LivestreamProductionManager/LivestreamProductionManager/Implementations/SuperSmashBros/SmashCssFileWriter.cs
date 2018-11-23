using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashCssFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new CssTemplateFileReader();
        private readonly SmashTextReplacer _smashTextReplacer = new SmashTextReplacer();

        public void WriteSinglesCssFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSinglesTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceCssForSingles(templateCssFile, singlesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "css/content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void WriteDoublesCssFile(string pathToFormat, DoublesCssModel doublesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosDoublesTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceCssForDoubles(templateCssFile, doublesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "css/content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}