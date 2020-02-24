using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;
using Serilog;
using System;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashCssReplacer : ISmashValuesReplacer
    {
        public string ReplaceValuesForSingles(string fileTemplate, SinglesCssModel singlesCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("player1NameTextPLACEHOLDER", singlesCssModel.Player1.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player1TwitterTextPLACEHOLDER", singlesCssModel.Player1.Twitter);

                fileTemplate = fileTemplate.Replace("player1TwitchTextPLACEHOLDER", singlesCssModel.Player1.Twitch);

                fileTemplate = fileTemplate.Replace("player1ScoreTextPLACEHOLDER", singlesCssModel.Player1.Score);

                fileTemplate = fileTemplate.Replace("player1CharacterPLACEHOLDER", singlesCssModel.Player1.CharacterPath);

                fileTemplate = fileTemplate.Replace("player1PortPLACEHOLDER", singlesCssModel.Player1.PortPath);

                fileTemplate = fileTemplate.Replace("player2NameTextPLACEHOLDER", singlesCssModel.Player2.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player2TwitterTextPLACEHOLDER", singlesCssModel.Player2.Twitter);

                fileTemplate = fileTemplate.Replace("player2TwitchTextPLACEHOLDER", singlesCssModel.Player2.Twitch);

                fileTemplate = fileTemplate.Replace("player2ScoreTextPLACEHOLDER", singlesCssModel.Player2.Score);

                fileTemplate = fileTemplate.Replace("player2CharacterPLACEHOLDER", singlesCssModel.Player2.CharacterPath);

                fileTemplate = fileTemplate.Replace("player2PortPLACEHOLDER", singlesCssModel.Player2.PortPath);

                fileTemplate = fileTemplate.Replace("tournamentTextPLACEHOLDER", singlesCssModel.Tournament);

                fileTemplate = fileTemplate.Replace("extraTextPLACEHOLDER", singlesCssModel.Extra);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", singlesCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", singlesCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }            
        }
        
        public string ReplaceValuesForDoubles(string fileTemplate, DoublesCssModel doublesCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("team1NameTextPLACEHOLDER", doublesCssModel.Team1.Name);

                fileTemplate = fileTemplate.Replace("team1ScoreTextPLACEHOLDER", doublesCssModel.Team1.Score);

                fileTemplate = fileTemplate.Replace("team1NamesTextPLACEHOLDER", doublesCssModel.Team1.PlayerNamesAndSponsors);

                fileTemplate = fileTemplate.Replace("team1TwittersTextPLACEHOLDER", doublesCssModel.Team1.Twitters);

                fileTemplate = fileTemplate.Replace("team1TwitchesTextPLACEHOLDER", doublesCssModel.Team1.Twitches);

                fileTemplate = fileTemplate.Replace("team1CharactersPLACEHOLDER", doublesCssModel.Team1.CharacterPaths);

                fileTemplate = fileTemplate.Replace("team1PortsPLACEHOLDER", doublesCssModel.Team1.PortPaths);

                fileTemplate = fileTemplate.Replace("team2NameTextPLACEHOLDER", doublesCssModel.Team2.Name);

                fileTemplate = fileTemplate.Replace("team2ScoreTextPLACEHOLDER", doublesCssModel.Team2.Score);

                fileTemplate = fileTemplate.Replace("team2NamesTextPLACEHOLDER", doublesCssModel.Team2.PlayerNamesAndSponsors);

                fileTemplate = fileTemplate.Replace("team2TwittersTextPLACEHOLDER", doublesCssModel.Team2.Twitters);

                fileTemplate = fileTemplate.Replace("team2TwitchesTextPLACEHOLDER", doublesCssModel.Team2.Twitches);

                fileTemplate = fileTemplate.Replace("team2CharactersPLACEHOLDER", doublesCssModel.Team2.CharacterPaths);

                fileTemplate = fileTemplate.Replace("team2PortsPLACEHOLDER", doublesCssModel.Team2.PortPaths);

                fileTemplate = fileTemplate.Replace("tournamentTextPLACEHOLDER", doublesCssModel.Tournament);

                fileTemplate = fileTemplate.Replace("extraTextPLACEHOLDER", doublesCssModel.Extra);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", doublesCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", doublesCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }            
        }

        public string ReplaceValuesForCrews(string fileTemplate, CrewsCssModel crewsCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("crew1NameTextPLACEHOLDER", crewsCssModel.Crew1.Name);

                var crew1Players = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Players += crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew1PlayersTextPLACEHOLDER", crew1Players);

                var crew1Twitters = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Twitters += crewsCssModel.Crew1.CrewPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew1TwittersTextPLACEHOLDER", crew1Twitters);

                var crew1Characters = "";
                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    crew1Characters += crewsCssModel.Crew1.CrewPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew1CharactersPLACEHOLDER", crew1Characters);

                fileTemplate = fileTemplate.Replace("crew1StocksLeftTextPLACEHOLDER", crewsCssModel.Crew1.StocksLeft);

                fileTemplate = fileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsCssModel.Crew1.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew1PortPLACEHOLDER", crewsCssModel.Crew1.PortPath);

                fileTemplate = fileTemplate.Replace("crew2NameTextPLACEHOLDER", crewsCssModel.Crew2.Name);

                var crew2Players = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Players += crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew2PlayersTextPLACEHOLDER", crew2Players);

                var crew2Twitters = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Twitters += crewsCssModel.Crew2.CrewPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew2TwittersTextPLACEHOLDER", crew2Twitters);

                var crew2Characters = "";
                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    crew2Characters += crewsCssModel.Crew2.CrewPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("crew2CharactersPLACEHOLDER", crew2Characters);

                fileTemplate = fileTemplate.Replace("crew2StocksLeftTextPLACEHOLDER", crewsCssModel.Crew2.StocksLeft);

                fileTemplate = fileTemplate.Replace("crew2CharacterPLACEHOLDER", crewsCssModel.Crew2.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew2PortPLACEHOLDER", crewsCssModel.Crew2.PortPath);

                fileTemplate = fileTemplate.Replace("tournamentTextPLACEHOLDER", crewsCssModel.Tournament);

                fileTemplate = fileTemplate.Replace("extraTextPLACEHOLDER", crewsCssModel.Extra);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", crewsCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", crewsCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceValuesForSquadStrike(string fileTemplate, SquadStrikeCssModel squadStrikeCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("squad1NameTextPLACEHOLDER", squadStrikeCssModel.Squad1.Name);

                var squad1Players = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Players += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1PlayersTextPLACEHOLDER", squad1Players);

                var squad1Twitters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Twitters += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1TwittersTextPLACEHOLDER", squad1Twitters);

                var squad1Characters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Characters += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1CharactersPLACEHOLDER", squad1Characters);

                fileTemplate = fileTemplate.Replace("squad1ScoreTextPLACEHOLDER", squadStrikeCssModel.Squad1.Score);

                fileTemplate = fileTemplate.Replace("squad1PortPLACEHOLDER", squadStrikeCssModel.Squad1.PortPath);

                fileTemplate = fileTemplate.Replace("squad2NameTextPLACEHOLDER", squadStrikeCssModel.Squad2.Name);

                var squad2Players = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Players += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2PlayersTextPLACEHOLDER", squad2Players);

                var squad2Twitters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Twitters += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2TwittersTextPLACEHOLDER", squad2Twitters);

                var squad2Characters = "";
                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Characters += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2CharactersPLACEHOLDER", squad2Characters);

                fileTemplate = fileTemplate.Replace("squad2ScoreTextPLACEHOLDER", squadStrikeCssModel.Squad2.Score);

                fileTemplate = fileTemplate.Replace("squad2PortPLACEHOLDER", squadStrikeCssModel.Squad2.PortPath);

                fileTemplate = fileTemplate.Replace("tournamentTextPLACEHOLDER", squadStrikeCssModel.Tournament);

                fileTemplate = fileTemplate.Replace("extraTextPLACEHOLDER", squadStrikeCssModel.Extra);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", squadStrikeCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", squadStrikeCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceValuesForSinglesNextSet(string fileTemplate, SinglesNextSetCssModel singlesNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("player1NameTextPLACEHOLDER", singlesNextSetCssModel.Player1.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player1TwitterTextPLACEHOLDER", singlesNextSetCssModel.Player1.Twitter);

                fileTemplate = fileTemplate.Replace("player1TwitchTextPLACEHOLDER", singlesNextSetCssModel.Player1.Twitch);

                fileTemplate = fileTemplate.Replace("player1CharacterPLACEHOLDER", singlesNextSetCssModel.Player1.CharacterPath);

                fileTemplate = fileTemplate.Replace("player1PortPLACEHOLDER", singlesNextSetCssModel.Player1.PortPath);

                fileTemplate = fileTemplate.Replace("player2NameTextPLACEHOLDER", singlesNextSetCssModel.Player2.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player2TwitterTextPLACEHOLDER", singlesNextSetCssModel.Player2.Twitter);

                fileTemplate = fileTemplate.Replace("player2TwitchTextPLACEHOLDER", singlesNextSetCssModel.Player2.Twitch);

                fileTemplate = fileTemplate.Replace("player2CharacterPLACEHOLDER", singlesNextSetCssModel.Player2.CharacterPath);

                fileTemplate = fileTemplate.Replace("player2PortPLACEHOLDER", singlesNextSetCssModel.Player2.PortPath);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", singlesNextSetCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", singlesNextSetCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceValuesForDoublesNextSet(string fileTemplate, DoublesNextSetCssModel doublesNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("team1NameTextPLACEHOLDER", doublesNextSetCssModel.Team1.Name);

                fileTemplate = fileTemplate.Replace("team1NamesTextPLACEHOLDER", doublesNextSetCssModel.Team1.PlayerNamesAndSponsors);

                fileTemplate = fileTemplate.Replace("team1TwittersTextPLACEHOLDER", doublesNextSetCssModel.Team1.Twitters);

                fileTemplate = fileTemplate.Replace("team1TwitchesTextPLACEHOLDER", doublesNextSetCssModel.Team1.Twitches);

                fileTemplate = fileTemplate.Replace("team1CharactersPLACEHOLDER", doublesNextSetCssModel.Team1.CharacterPaths);

                fileTemplate = fileTemplate.Replace("team1PortsPLACEHOLDER", doublesNextSetCssModel.Team1.PortPaths);

                fileTemplate = fileTemplate.Replace("team2NameTextPLACEHOLDER", doublesNextSetCssModel.Team2.Name);

                fileTemplate = fileTemplate.Replace("team2NamesTextPLACEHOLDER", doublesNextSetCssModel.Team2.PlayerNamesAndSponsors);

                fileTemplate = fileTemplate.Replace("team2TwittersTextPLACEHOLDER", doublesNextSetCssModel.Team2.Twitters);

                fileTemplate = fileTemplate.Replace("team2TwitchesTextPLACEHOLDER", doublesNextSetCssModel.Team2.Twitches);

                fileTemplate = fileTemplate.Replace("team2CharactersPLACEHOLDER", doublesNextSetCssModel.Team2.CharacterPaths);

                fileTemplate = fileTemplate.Replace("team2PortsPLACEHOLDER", doublesNextSetCssModel.Team2.PortPaths);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", doublesNextSetCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", doublesNextSetCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceValuesForCrewsNextSet(string fileTemplate, CrewsNextSetCssModel crewsNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("crew1NameTextPLACEHOLDER", crewsNextSetCssModel.Crew1.Name);

                fileTemplate = fileTemplate.Replace("crew1StocksLeftTextPLACEHOLDER", crewsNextSetCssModel.Crew1.StocksLeft);

                fileTemplate = fileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsNextSetCssModel.Crew1.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew1PortPLACEHOLDER", crewsNextSetCssModel.Crew1.PortPath);

                fileTemplate = fileTemplate.Replace("crew2NameTextPLACEHOLDER", crewsNextSetCssModel.Crew2.Name);

                fileTemplate = fileTemplate.Replace("crew2StocksLeftTextPLACEHOLDER", crewsNextSetCssModel.Crew2.StocksLeft);

                fileTemplate = fileTemplate.Replace("crew2CharacterPLACEHOLDER", crewsNextSetCssModel.Crew2.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew2PortPLACEHOLDER", crewsNextSetCssModel.Crew2.PortPath);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", crewsNextSetCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", crewsNextSetCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public string ReplaceValuesForSquadStrikeNextSet(string fileTemplate, SquadStrikeNextSetCssModel squadStrikeNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("squad1NameTextPLACEHOLDER", squadStrikeNextSetCssModel.Squad1.Name);

                var squad1Players = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Players += squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1PlayersTextPLACEHOLDER", squad1Players);

                var squad1Twitters = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Twitters += squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1TwittersTextPLACEHOLDER", squad1Twitters);

                var squad1Characters = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    squad1Characters += squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad1CharactersPLACEHOLDER", squad1Characters);

                fileTemplate = fileTemplate.Replace("squad1PortPLACEHOLDER", squadStrikeNextSetCssModel.Squad1.PortPath);

                fileTemplate = fileTemplate.Replace("squad2NameTextPLACEHOLDER", squadStrikeNextSetCssModel.Squad2.Name);

                var squad2Players = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Players += squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2PlayersTextPLACEHOLDER", squad2Players);

                var squad2Twitters = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Twitters += squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].Twitter + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2TwittersTextPLACEHOLDER", squad2Twitters);

                var squad2Characters = "";
                for (var i = 0; i < squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    squad2Characters += squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath + "\r\n";
                }
                fileTemplate = fileTemplate.Replace("squad2CharactersPLACEHOLDER", squad2Characters);

                fileTemplate = fileTemplate.Replace("squad2PortPLACEHOLDER", squadStrikeNextSetCssModel.Squad2.PortPath);

                fileTemplate = fileTemplate.Replace("roundTextPLACEHOLDER", squadStrikeNextSetCssModel.Round);

                fileTemplate = fileTemplate.Replace("bestOfTextPLACEHOLDER", squadStrikeNextSetCssModel.BestOf);

                return fileTemplate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}