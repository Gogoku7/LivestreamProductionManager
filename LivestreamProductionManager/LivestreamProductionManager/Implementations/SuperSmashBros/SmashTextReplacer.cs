using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using System;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashTextReplacer
    {
        public string ReplaceCssForSingles(string cssFileTemplate, SinglesCssModel singlesCssModel)
        {
            try
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

                cssFileTemplate = cssFileTemplate.Replace("tournamentTextPLACEHOLDER", singlesCssModel.Tournament);

                cssFileTemplate = cssFileTemplate.Replace("extraTextPLACEHOLDER", singlesCssModel.Extra);

                cssFileTemplate = cssFileTemplate.Replace("roundTextPLACEHOLDER", singlesCssModel.Round);

                cssFileTemplate = cssFileTemplate.Replace("bestOfTextPLACEHOLDER", singlesCssModel.BestOf);

                return cssFileTemplate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }            
        }
        
        public string ReplaceCssForDoubles(string cssFileTemplate, DoublesCssModel doublesCssModel)
        {
            try
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

                cssFileTemplate = cssFileTemplate.Replace("tournamentTextPLACEHOLDER", doublesCssModel.Tournament);

                cssFileTemplate = cssFileTemplate.Replace("extraTextPLACEHOLDER", doublesCssModel.Extra);

                cssFileTemplate = cssFileTemplate.Replace("roundTextPLACEHOLDER", doublesCssModel.Round);

                cssFileTemplate = cssFileTemplate.Replace("bestOfTextPLACEHOLDER", doublesCssModel.BestOf);

                return cssFileTemplate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }            
        }

        public string ReplaceCssForCrews(string cssFileTemplate, CrewsCssModel crewsCssModel)
        {
            try
            {
                cssFileTemplate = cssFileTemplate.Replace("crew1NameTextPLACEHOLDER", crewsCssModel.Crew1.Name);

                cssFileTemplate = cssFileTemplate.Replace("crew1PlayersTextPLACEHOLDER", crewsCssModel.Crew1.PlayerNamesAndSponsors);

                cssFileTemplate = cssFileTemplate.Replace("crew1TwittersTextPLACEHOLDER", crewsCssModel.Crew1.Twitters);

                cssFileTemplate = cssFileTemplate.Replace("crew1StocksLeftTextPLACEHOLDER", crewsCssModel.Crew1.StocksLeft);

                cssFileTemplate = cssFileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsCssModel.Crew1.CharacterPath);

                cssFileTemplate = cssFileTemplate.Replace("crew1PortPLACEHOLDER", crewsCssModel.Crew1.PortPath);

                cssFileTemplate = cssFileTemplate.Replace("crew2NameTextPLACEHOLDER", crewsCssModel.Crew2.Name);

                cssFileTemplate = cssFileTemplate.Replace("crew2PlayersTextPLACEHOLDER", crewsCssModel.Crew2.PlayerNamesAndSponsors);

                cssFileTemplate = cssFileTemplate.Replace("crew2TwittersTextPLACEHOLDER", crewsCssModel.Crew2.Twitters);

                cssFileTemplate = cssFileTemplate.Replace("crew2StocksLeftTextPLACEHOLDER", crewsCssModel.Crew2.StocksLeft);

                cssFileTemplate = cssFileTemplate.Replace("crew2CharacterPLACEHOLDER", crewsCssModel.Crew2.CharacterPath);

                cssFileTemplate = cssFileTemplate.Replace("crew2PortPLACEHOLDER", crewsCssModel.Crew2.PortPath);

                cssFileTemplate = cssFileTemplate.Replace("tournamentTextPLACEHOLDER", crewsCssModel.Tournament);

                cssFileTemplate = cssFileTemplate.Replace("extraTextPLACEHOLDER", crewsCssModel.Extra);

                cssFileTemplate = cssFileTemplate.Replace("roundTextPLACEHOLDER", crewsCssModel.Round);

                cssFileTemplate = cssFileTemplate.Replace("bestOfTextPLACEHOLDER", crewsCssModel.BestOf);

                return cssFileTemplate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}