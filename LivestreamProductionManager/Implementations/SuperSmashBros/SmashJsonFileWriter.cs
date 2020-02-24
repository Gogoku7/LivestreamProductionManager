using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashJsonFileWriter : ISmashFileWriter
    {
        public void WriteSinglesFile(string pathToFormat, SinglesCssModel singlesCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteDoublesFile(string pathToFormat, DoublesCssModel doublesCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteCrewsFile(string pathToFormat, CrewsCssModel crewsCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteSquadStrikeFile(string pathToFormat, SquadStrikeCssModel squadStrikeCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteSinglesNextSetFile(string pathToNextSetFormat, SinglesNextSetCssModel singlesNextSetCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteDoublesNextSetFile(string pathToNextSetFormat, DoublesNextSetCssModel doublesNextSetCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteCrewsNextSetFile(string pathToNextSetFormat, CrewsNextSetCssModel crewsNextSetCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteSquadStrikeNextSetFile(string pathToNextSetFormat, SquadStrikeNextSetCssModel squadStrikeNextSetCssModel)
        {
            throw new NotImplementedException();
        }

        public void WriteJsonFile(string pathToFormat, List<SelectorValueModel> selectorValueModels)
        {
            try
            {
                var file = new FileInfo(HttpContext.Current.Server.MapPath(pathToFormat + "JSON/Content.json"));
                file.Directory.Create();

                File.WriteAllText(file.FullName, JsonConvert.SerializeObject(selectorValueModels, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}