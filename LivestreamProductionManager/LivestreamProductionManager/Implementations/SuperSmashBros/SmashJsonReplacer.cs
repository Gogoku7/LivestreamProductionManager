using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashJsonReplacer : ISmashValuesReplacer
    {
        public string ReplaceValuesForSingles(string fileTemplate, SinglesCssModel singlesCssModel)
        {
            try
            {
                string fileContent = singlesCssModel.Player1.NameAndSponsor;
                fileContent += singlesCssModel.Player1.Twitter;
                fileContent += singlesCssModel.Player1.Score;
                fileContent += singlesCssModel.Player1.CharacterPath;
                fileContent += singlesCssModel.Player1.PortPath;

                fileContent += singlesCssModel.Player2.NameAndSponsor;
                fileContent += singlesCssModel.Player2.Twitter;
                fileContent += singlesCssModel.Player2.Score;
                fileContent += singlesCssModel.Player2.CharacterPath;
                fileContent += singlesCssModel.Player2.PortPath;

                fileContent += singlesCssModel.Tournament;
                fileContent += singlesCssModel.Extra;
                fileContent += singlesCssModel.Round;
                fileContent += singlesCssModel.BestOf;

                return fileTemplate.Replace("CONTENT", fileContent.Substring(0, fileContent.Length - 3));
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
                var fileContent = doublesCssModel.Team1.Name;
                fileContent += doublesCssModel.Team1.Score;
                fileContent += doublesCssModel.Team1.PlayerNamesAndSponsors;
                fileContent += doublesCssModel.Team1.CharacterPaths;
                fileContent += doublesCssModel.Team1.PortPaths;

                fileContent += doublesCssModel.Team2.Name;
                fileContent += doublesCssModel.Team2.Score;
                fileContent += doublesCssModel.Team2.PlayerNamesAndSponsors;
                fileContent += doublesCssModel.Team2.CharacterPaths;
                fileContent += doublesCssModel.Team2.PortPaths;


                fileContent += doublesCssModel.Tournament;
                fileContent += doublesCssModel.Extra;
                fileContent += doublesCssModel.Round;
                fileContent += doublesCssModel.BestOf;

                return fileTemplate.Replace("CONTENT", fileContent.Substring(0, fileContent.Length - 3));
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
                var fileContent = crewsCssModel.Crew1.Name;
                fileContent += crewsCssModel.Crew1.CharacterPath;
                fileContent += crewsCssModel.Crew1.PortPath;
                fileContent += crewsCssModel.Crew1.StocksLeft;

                for (var i = 0; i < crewsCssModel.Crew1.CrewPlayerCssModels.Count; i++)
                {
                    fileContent += crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor;
                    fileContent += crewsCssModel.Crew1.CrewPlayerCssModels[i].Twitter;
                    fileContent += crewsCssModel.Crew1.CrewPlayerCssModels[i].CharacterPath;
                }

                fileContent += crewsCssModel.Crew2.Name;
                fileContent += crewsCssModel.Crew2.CharacterPath;
                fileContent += crewsCssModel.Crew2.PortPath;
                fileContent += crewsCssModel.Crew2.StocksLeft;

                for (var i = 0; i < crewsCssModel.Crew2.CrewPlayerCssModels.Count; i++)
                {
                    fileContent += crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor;
                    fileContent += crewsCssModel.Crew2.CrewPlayerCssModels[i].Twitter;
                    fileContent += crewsCssModel.Crew2.CrewPlayerCssModels[i].CharacterPath;
                }

                fileContent += crewsCssModel.Tournament;
                fileContent += crewsCssModel.Extra;
                fileContent += crewsCssModel.Round;
                fileContent += crewsCssModel.BestOf;

                return fileTemplate.Replace("CONTENT", fileContent.Substring(0, fileContent.Length - 3));
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
                var fileContent = squadStrikeCssModel.Squad1.Name;
                fileContent += squadStrikeCssModel.Squad1.PortPath;
                fileContent += squadStrikeCssModel.Squad1.Score;

                for (var i = 0; i < squadStrikeCssModel.Squad1.SquadPlayerCssModels.Count; i++)
                {
                    fileContent += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor;
                    fileContent += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].Twitter;
                    fileContent += squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath;
                }

                fileContent += squadStrikeCssModel.Squad2.Name;
                fileContent += squadStrikeCssModel.Squad2.PortPath;
                fileContent += squadStrikeCssModel.Squad2.Score;

                for (var i = 0; i < squadStrikeCssModel.Squad2.SquadPlayerCssModels.Count; i++)
                {
                    fileContent += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor;
                    fileContent += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].Twitter;
                    fileContent += squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath;
                }

                fileContent += squadStrikeCssModel.Tournament;
                fileContent += squadStrikeCssModel.Extra;
                fileContent += squadStrikeCssModel.Round;
                fileContent += squadStrikeCssModel.BestOf;

                return fileTemplate.Replace("CONTENT", fileContent.Substring(0, fileContent.Length - 3));
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}