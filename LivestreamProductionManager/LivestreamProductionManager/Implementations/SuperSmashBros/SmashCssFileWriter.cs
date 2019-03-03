﻿using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new CssTemplateFileReader();
        private readonly SmashTextReplacer _smashTextReplacer = new SmashTextReplacer();

        public void WriteSinglesCssFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosSinglesTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceCssForSingles(templateCssFile, singlesCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
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

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void WriteCrewsCssFile(string pathToFormat, CrewsCssModel crewsCssModel)
        {
            try
            {
                var templateCssFile = _templateFileReader.ReadTemplateFile("SuperSmashBros/SuperSmashBrosCrewsTemplate.css");
                var cssFileContent = _smashTextReplacer.ReplaceCssForCrews(templateCssFile, crewsCssModel);

                File.WriteAllText(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css"), cssFileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}