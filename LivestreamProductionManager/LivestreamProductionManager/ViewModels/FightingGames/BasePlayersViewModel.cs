namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class BasePlayersViewModel : TournamentViewModel
    {
        public string Series { get; set; }
        public string Game { get; set; }
        public string Format { get; set; }
        public string PathToSeries { get; set; }
        public string PathToGame { get; set; }
        public string PathToFormat { get; set; }

        public BasePlayersViewModel()
        {

        }

        public BasePlayersViewModel(string series, string game, string format, string pathToSeries, string pathToGame, string pathToFormat)
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