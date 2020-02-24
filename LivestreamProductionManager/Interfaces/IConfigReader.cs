using LivestreamProductionManager.Models.FightingGames.Skins;
using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.Settings;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces
{
    public interface IConfigReader
    {
        List<Series> GetSeries();
        List<Game> GetGames(string pathToSeries);
        List<Format> GetFormats(string pathToGame);
        List<CharacterViewModel> GetCharactersFromConfig(string pathToGame);
        List<PortViewModel> GetPortsFromConfig(string pathToGame);
        List<CountryViewModel> GetCountriesFromConfig();
        SkinsConfig GetSkins(string pathToGame);
        List<Setting> GetSettings(string pathToSettingsFile);
    }
}