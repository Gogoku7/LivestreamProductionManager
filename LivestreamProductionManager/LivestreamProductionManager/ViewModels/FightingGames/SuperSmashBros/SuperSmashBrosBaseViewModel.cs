using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros
{
    public class SuperSmashBrosBaseViewModel : BasePlayersViewModel
    {
        //TODO: Improve the inheritance, it's currently not good...
        public List<CharacterViewModel> Characters { get; set; }
        public List<PortViewModel> Ports { get; set; }

        public SuperSmashBrosBaseViewModel()
        {

        }

        public SuperSmashBrosBaseViewModel(string series, string game, string format, string pathToSeries, string pathToGame, string pathToFormat)
        {
            Series = series;
            Game = game;
            Format = format;
            PathToSeries = pathToSeries;
            PathToGame = pathToGame;
            PathToFormat = pathToFormat;
        }
    }
}