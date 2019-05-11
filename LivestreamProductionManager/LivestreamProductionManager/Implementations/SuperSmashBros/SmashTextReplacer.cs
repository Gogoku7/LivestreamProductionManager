using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using Serilog;
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
                Log.Error(ex, ex.Message);
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
                Log.Error(ex, ex.Message);
                throw;
            }            
        }

        public string ReplaceCssForCrews(string cssFileTemplate, CrewsCssModel crewsCssModel)
        {
            try
            {
                cssFileTemplate = cssFileTemplate.Replace("crew1NameTextPLACEHOLDER", crewsCssModel.Crew1.Name);

                var crew1Players = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Players += crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew1PlayersTextPLACEHOLDER", crew1Players);

                var crew1Twitters = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Twitters += crewsCssModel.Crew1.CrewPlayerCssModels[i].Twitter + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew1TwittersTextPLACEHOLDER", crew1Twitters);

                var crew1Characters = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Characters += crewsCssModel.Crew1.CrewPlayerCssModels[i].CharacterPath + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew1CharactersPLACEHOLDER", crew1Characters);

                cssFileTemplate = cssFileTemplate.Replace("crew1StocksLeftTextPLACEHOLDER", crewsCssModel.Crew1.StocksLeft);

                cssFileTemplate = cssFileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsCssModel.Crew1.CharacterPath);

                cssFileTemplate = cssFileTemplate.Replace("crew1PortPLACEHOLDER", crewsCssModel.Crew1.PortPath);

                cssFileTemplate = cssFileTemplate.Replace("crew2NameTextPLACEHOLDER", crewsCssModel.Crew2.Name);

                var crew2Players = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Players += crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew2PlayersTextPLACEHOLDER", crew2Players);

                var crew2Twitters = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Twitters += crewsCssModel.Crew2.CrewPlayerCssModels[i].Twitter + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew2TwittersTextPLACEHOLDER", crew2Twitters);

                var crew2Characters = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Characters += crewsCssModel.Crew2.CrewPlayerCssModels[i].CharacterPath + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("crew2CharactersPLACEHOLDER", crew2Characters);

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
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceCssForSquadStrike(string cssFileTemplate, SquadStrikeCssModel squadStrikeCssModel)
        {
            try
            {
                cssFileTemplate = cssFileTemplate.Replace("squad1NameTextPLACEHOLDER", squadStrikeCssModel.Squad1.Name);

                var squad1Players = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Players += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad1PlayersTextPLACEHOLDER", squad1Players);

                var squad1Twitters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Twitters += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad1TwittersTextPLACEHOLDER", squad1Twitters);

                var squad1Characters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Characters += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad1CharactersPLACEHOLDER", squad1Characters);

                cssFileTemplate = cssFileTemplate.Replace("squad1ScoreTextPLACEHOLDER", squadStrikeCssModel.Squad1.Score);

                cssFileTemplate = cssFileTemplate.Replace("squad1PortPLACEHOLDER", squadStrikeCssModel.Squad1.PortPath);

                cssFileTemplate = cssFileTemplate.Replace("squad2NameTextPLACEHOLDER", squadStrikeCssModel.Squad2.Name);

                var squad2Players = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Players += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad2PlayersTextPLACEHOLDER", squad2Players);

                var squad2Twitters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Twitters += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad2TwittersTextPLACEHOLDER", squad2Twitters);

                var squad2Characters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Characters += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                cssFileTemplate = cssFileTemplate.Replace("squad2CharactersPLACEHOLDER", squad2Characters);

                cssFileTemplate = cssFileTemplate.Replace("squad2ScoreTextPLACEHOLDER", squadStrikeCssModel.Squad2.Score);

                cssFileTemplate = cssFileTemplate.Replace("squad2PortPLACEHOLDER", squadStrikeCssModel.Squad2.PortPath);

                cssFileTemplate = cssFileTemplate.Replace("tournamentTextPLACEHOLDER", squadStrikeCssModel.Tournament);

                cssFileTemplate = cssFileTemplate.Replace("extraTextPLACEHOLDER", squadStrikeCssModel.Extra);

                cssFileTemplate = cssFileTemplate.Replace("roundTextPLACEHOLDER", squadStrikeCssModel.Round);

                cssFileTemplate = cssFileTemplate.Replace("bestOfTextPLACEHOLDER", squadStrikeCssModel.BestOf);

                return cssFileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}