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
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToFormat + "Css/Content.css")))
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