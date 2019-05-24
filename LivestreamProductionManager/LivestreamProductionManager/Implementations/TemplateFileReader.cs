using LivestreamProductionManager.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations
{
    public class TemplateFileReader : ITemplateFileReader
    {
        private readonly string _templatesFolderPath = "~/FightingGames/CssTemplates/";
        //private readonly string _cssTemplatesFolderPath = "~/FightingGames/JsonTemplates/";

        public TemplateFileReader(string templatesFolderPath)
        {
            _templatesFolderPath = templatesFolderPath;
        }

        public string ReadTemplateFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(_templatesFolderPath + fileName)))
                {
                    using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(_templatesFolderPath + fileName)))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                else
                {
                    throw new FileNotFoundException($"No file found at path: {_templatesFolderPath + fileName}.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}