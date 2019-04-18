using LivestreamProductionManager.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations
{
    public class CssTemplateFileReader : ITemplateFileReader
    {
        private readonly string _cssTemplatesFolderPath = "~/FightingGames/CssTemplates/";

        public string ReadTemplateFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(_cssTemplatesFolderPath + fileName)))
                {
                    using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(_cssTemplatesFolderPath + fileName)))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                else
                {
                    throw new FileNotFoundException($"No file found at path: {_cssTemplatesFolderPath + fileName}.");
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