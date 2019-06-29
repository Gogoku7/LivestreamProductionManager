using LivestreamProductionManager.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations
{
    public class FileReader : IFileReader
    {
        public string ReadCssFile(string pathToFormat)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToFormat + "CSS/Content.css")))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReadJsonFile(string pathToFormat)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json")))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReadReadMeFile(string pathToFormat)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToFormat + "ReadMe.json")))
                {
                    return streamReader.ReadToEnd();
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