using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Models.FightingGames.Skins;
using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.Settings;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LivestreamProductionManager.Implementations
{
    public class JsonFileConfigReader : IConfigReader
    {
        public List<Series> GetSeries()
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath("~/FightingGames/SeriesConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<Series>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<Game> GetGames(string pathToSeries)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToSeries + "GamesConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<Game>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<Format> GetFormats(string pathToGame)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToGame + "FormatsConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<Format>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<CharacterViewModel> GetCharactersFromConfig(string pathToGame)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToGame + "CharactersConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<CharacterViewModel>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<PortViewModel> GetPortsFromConfig(string pathToGame)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToGame + "PortsConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<PortViewModel>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<CountryViewModel> GetCountriesFromConfig()
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath("~/FightingGames/Flags/CountriesConfig.json")))
                {
                    return JsonConvert.DeserializeObject<List<CountryViewModel>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public SkinsConfig GetSkins(string pathToGame)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToGame + "CharacterIcons/SkinsConfig.json")))
                {
                    return JsonConvert.DeserializeObject<SkinsConfig>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public List<Setting> GetSettings(string pathToSettingsFile)
        {
            try
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(pathToSettingsFile)))
                {
                    return JsonConvert.DeserializeObject<List<Setting>>(streamReader.ReadToEnd());
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