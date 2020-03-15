using LivestreamProductionManager.Interfaces.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet;
using Serilog;
using System;

namespace LivestreamProductionManager.Implementations.TraditionalFG
{
    public class TraditionalFGCssReplacer : ITraditionalFGValuesReplacer
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

                fileTemplate = fileTemplate.Replace("player1CountryPLACEHOLDER", singlesCssModel.Player1.CountryPath);

                fileTemplate = fileTemplate.Replace("player2NameTextPLACEHOLDER", singlesCssModel.Player2.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player2TwitterTextPLACEHOLDER", singlesCssModel.Player2.Twitter);

                fileTemplate = fileTemplate.Replace("player2TwitchTextPLACEHOLDER", singlesCssModel.Player2.Twitch);

                fileTemplate = fileTemplate.Replace("player2ScoreTextPLACEHOLDER", singlesCssModel.Player2.Score);

                fileTemplate = fileTemplate.Replace("player2CharacterPLACEHOLDER", singlesCssModel.Player2.CharacterPath);

                fileTemplate = fileTemplate.Replace("player2CountryPLACEHOLDER", singlesCssModel.Player2.CountryPath);

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

                fileTemplate = fileTemplate.Replace("crew1ScoreTextPLACEHOLDER", crewsCssModel.Crew1.Score);

                fileTemplate = fileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsCssModel.Crew1.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew1CountryPLACEHOLDER", crewsCssModel.Crew1.CountryPath);

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

                fileTemplate = fileTemplate.Replace("crew2ScoreTextPLACEHOLDER", crewsCssModel.Crew2.Score);

                fileTemplate = fileTemplate.Replace("crew2CharacterPLACEHOLDER", crewsCssModel.Crew2.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew2CountryPLACEHOLDER", crewsCssModel.Crew2.CountryPath);

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

        public string ReplaceValuesForSinglesNextSet(string fileTemplate, SinglesNextSetCssModel singlesNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("player1NameTextPLACEHOLDER", singlesNextSetCssModel.Player1.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player1TwitterTextPLACEHOLDER", singlesNextSetCssModel.Player1.Twitter);

                fileTemplate = fileTemplate.Replace("player1TwitchTextPLACEHOLDER", singlesNextSetCssModel.Player1.Twitch);

                fileTemplate = fileTemplate.Replace("player1CharacterPLACEHOLDER", singlesNextSetCssModel.Player1.CharacterPath);

                fileTemplate = fileTemplate.Replace("player1CountryPLACEHOLDER", singlesNextSetCssModel.Player1.CountryPath);

                fileTemplate = fileTemplate.Replace("player2NameTextPLACEHOLDER", singlesNextSetCssModel.Player2.NameAndSponsor);

                fileTemplate = fileTemplate.Replace("player2TwitterTextPLACEHOLDER", singlesNextSetCssModel.Player2.Twitter);

                fileTemplate = fileTemplate.Replace("player2TwitchTextPLACEHOLDER", singlesNextSetCssModel.Player2.Twitch);

                fileTemplate = fileTemplate.Replace("player2CharacterPLACEHOLDER", singlesNextSetCssModel.Player2.CharacterPath);

                fileTemplate = fileTemplate.Replace("player2CountryPLACEHOLDER", singlesNextSetCssModel.Player2.CountryPath);

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

        public string ReplaceValuesForCrewsNextSet(string fileTemplate, CrewsNextSetCssModel crewsNextSetCssModel)
        {
            try
            {
                fileTemplate = fileTemplate.Replace("crew1NameTextPLACEHOLDER", crewsNextSetCssModel.Crew1.Name);

                fileTemplate = fileTemplate.Replace("crew1ScoreTextPLACEHOLDER", crewsNextSetCssModel.Crew1.Score);

                fileTemplate = fileTemplate.Replace("crew1CharacterPLACEHOLDER", crewsNextSetCssModel.Crew1.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew1CountryPLACEHOLDER", crewsNextSetCssModel.Crew1.CountryPath);

                fileTemplate = fileTemplate.Replace("crew2NameTextPLACEHOLDER", crewsNextSetCssModel.Crew2.Name);

                fileTemplate = fileTemplate.Replace("crew2ScoreTextPLACEHOLDER", crewsNextSetCssModel.Crew2.Score);

                fileTemplate = fileTemplate.Replace("crew2CharacterPLACEHOLDER", crewsNextSetCssModel.Crew2.CharacterPath);

                fileTemplate = fileTemplate.Replace("crew2CountryPLACEHOLDER", crewsNextSetCssModel.Crew2.CountryPath);

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
    }
}