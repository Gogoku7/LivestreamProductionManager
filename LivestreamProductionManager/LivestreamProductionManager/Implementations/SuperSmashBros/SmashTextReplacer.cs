using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashTextReplacer
    {
        public string ReplaceCssForSingles(string cssFileTemplate, SinglesCssModel singlesCssModel)
        {
            cssFileTemplate = cssFileTemplate.Replace("player1NameTextPLACEHOLDER", singlesCssModel.Player1.NameAndSponsor);

            cssFileTemplate = cssFileTemplate.Replace("player1TwitterTextPLACEHOLDER", singlesCssModel.Player1.Twitter);

            cssFileTemplate = cssFileTemplate.Replace("player1ScoreTextPLACEHOLDER", singlesCssModel.Player1.Score);

            cssFileTemplate = cssFileTemplate.Replace("player1CharacterPLACEHOLDER", singlesCssModel.Player1.CharacterPath);

            cssFileTemplate = cssFileTemplate.Replace("player1PortPLACEHOLDER", singlesCssModel.Player1.PortPath);

            cssFileTemplate = cssFileTemplate.Replace("player2NameTextPLACEHOLDER", singlesCssModel.Player2.NameAndSponsor);

            cssFileTemplate = cssFileTemplate.Replace("player2TwitterTextPLACEHOLDER", singlesCssModel.Player2.Twitter);

            cssFileTemplate = cssFileTemplate.Replace("player2ScoreTextPLACEHOLDER", singlesCssModel.Player2.Score);

            cssFileTemplate = cssFileTemplate.Replace("player2CharacterPLACEHOLDER", singlesCssModel.Player2.CharacterPath);

            cssFileTemplate = cssFileTemplate.Replace("player2PortPLACEHOLDER", singlesCssModel.Player2.PortPath);

            cssFileTemplate = cssFileTemplate.Replace("tournamentPLACEHOLDER", singlesCssModel.Tournament);

            cssFileTemplate = cssFileTemplate.Replace("extraPLACEHOLDER", singlesCssModel.Extra);

            cssFileTemplate = cssFileTemplate.Replace("roundPLACEHOLDER", singlesCssModel.Round);

            cssFileTemplate = cssFileTemplate.Replace("bestOfPLACEHOLDER", singlesCssModel.BestOf);

            return cssFileTemplate;
        }
        
        public string ReplaceCssForDoubles(string cssFileTemplate, DoublesCssModel doublesCssModel)
        {
            cssFileTemplate = cssFileTemplate.Replace("team1NameTextPLACEHOLDER", doublesCssModel.Team1.Name);

            cssFileTemplate = cssFileTemplate.Replace("team1ScoreTextPLACEHOLDER", doublesCssModel.Team1.Score);

            cssFileTemplate = cssFileTemplate.Replace("team1NamesTextPLACEHOLDER", doublesCssModel.Team1.PlayerNamesAndSponsors);

            cssFileTemplate = cssFileTemplate.Replace("team1CharactersPLACEHOLDER", doublesCssModel.Team1.CharacterPaths);

            cssFileTemplate = cssFileTemplate.Replace("team1PortsPLACEHOLDER", doublesCssModel.Team1.PortPaths);

            cssFileTemplate = cssFileTemplate.Replace("team2NameTextPLACEHOLDER", doublesCssModel.Team2.Name);

            cssFileTemplate = cssFileTemplate.Replace("team2ScoreTextPLACEHOLDER", doublesCssModel.Team2.Score);

            cssFileTemplate = cssFileTemplate.Replace("team2NamesTextPLACEHOLDER", doublesCssModel.Team2.PlayerNamesAndSponsors);

            cssFileTemplate = cssFileTemplate.Replace("team2CharactersPLACEHOLDER", doublesCssModel.Team2.CharacterPaths);

            cssFileTemplate = cssFileTemplate.Replace("team2PortsPLACEHOLDER", doublesCssModel.Team2.PortPaths);

            cssFileTemplate = cssFileTemplate.Replace("tournamentPLACEHOLDER", doublesCssModel.Tournament);

            cssFileTemplate = cssFileTemplate.Replace("extraPLACEHOLDER", doublesCssModel.Extra);

            cssFileTemplate = cssFileTemplate.Replace("roundPLACEHOLDER", doublesCssModel.Round);

            cssFileTemplate = cssFileTemplate.Replace("bestOfPLACEHOLDER", doublesCssModel.BestOf);

            return cssFileTemplate;
        }
    }
}