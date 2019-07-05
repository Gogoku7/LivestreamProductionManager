using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using Serilog;
using System;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashJsonOverlayManager : ISmashOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/JsonTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ISmashFileWriter _smashFileWriter = new SmashJsonFileWriter();

        private readonly string _textTemplateJson;

        public SmashJsonOverlayManager()
        {
            _textTemplateJson = _templatefileReader.ReadTemplateFile("TextTemplateFile.json");
        }

        public void UpdateSinglesOverlay(SinglesViewModel singlesViewModel)
        {
            try
            {
                var singlesCssModel = new SinglesCssModel();

                singlesCssModel.Player1.NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player1NameText", singlesViewModel.Player1.Name);
                singlesCssModel.Player1.NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, ".player1Sponsor", singlesViewModel.Player1.Sponsor);
                singlesCssModel.Player1.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player1TwitterText", singlesViewModel.Player1.Twitter);
                singlesCssModel.Player1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player1ScoreText", singlesViewModel.Player1.Score ?? "?");
                singlesCssModel.Player1.CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player1Character", singlesViewModel.Player1.Character);
                singlesCssModel.Player1.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player1Port", singlesViewModel.Player1.Port);

                singlesCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player2NameText", singlesViewModel.Player2.Name);
                singlesCssModel.Player2.NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, ".player2Sponsor", singlesViewModel.Player2.Sponsor);
                singlesCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player2TwitterText", singlesViewModel.Player2.Twitter);
                singlesCssModel.Player2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player2ScoreText", singlesViewModel.Player2.Score ?? "?");
                singlesCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player2Character", singlesViewModel.Player2.Character);
                singlesCssModel.Player2.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#player2Port", singlesViewModel.Player2.Port);

                singlesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#tournamentText", singlesViewModel.Tournament);
                singlesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#extraText", singlesViewModel.Extra);
                singlesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#roundText", singlesViewModel.Round);
                singlesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#bestOfText", singlesViewModel.BestOf);

                _smashFileWriter.WriteSinglesFile(singlesViewModel.PathToFormat, singlesCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateDoublesOverlay(DoublesViewModel doublesViewModel)
        {
            try
            {
                var doublesCssModel = new DoublesCssModel();

                doublesCssModel.Team1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#team1NameText", doublesViewModel.Team1.Name);
                doublesCssModel.Team1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#team1ScoreText", doublesViewModel.Team1.Score ?? "?");

                for (var i = 0; i < doublesViewModel.Team1.Players.Count; i++)
                {
                    doublesCssModel.Team1.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team1Player{i+1}NameText", doublesViewModel.Team1.Players[i].Name);
                    doublesCssModel.Team1.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".team1Player{i+1}Sponsor", doublesViewModel.Team1.Players[i].Sponsor);
                    doublesCssModel.Team1.CharacterPaths += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team1Player{i+1}Character", doublesViewModel.Team1.Players[i].Character);
                    doublesCssModel.Team1.PortPaths += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team1Player{i+1}Port", doublesViewModel.Team1.Players[i].Port);
                }

                doublesCssModel.Team2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#team2NameText", doublesViewModel.Team2.Name);
                doublesCssModel.Team2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#team2ScoreText", doublesViewModel.Team2.Score ?? "?");

                for (var i = 0; i < doublesViewModel.Team2.Players.Count; i++)
                {
                    doublesCssModel.Team2.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team2Player{i + 1}NameText", doublesViewModel.Team2.Players[i].Name);
                    doublesCssModel.Team2.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".team2Player{i + 1}Sponsor", doublesViewModel.Team2.Players[i].Sponsor);
                    doublesCssModel.Team2.CharacterPaths += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team2Player{i + 1}Character", doublesViewModel.Team2.Players[i].Character);
                    doublesCssModel.Team2.PortPaths += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#team2Player{i + 1}Port", doublesViewModel.Team2.Players[i].Port);
                }

                doublesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#tournamentText", doublesViewModel.Tournament);
                doublesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#extraText", doublesViewModel.Extra);
                doublesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#roundText", doublesViewModel.Round);
                doublesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#bestOfText", doublesViewModel.BestOf);

                _smashFileWriter.WriteDoublesFile(doublesViewModel.PathToFormat, doublesCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateCrewsOverlay(CrewsViewModel crewsViewModel)
        {
            try
            {
                var crewsCssModel = new CrewsCssModel();

                crewsCssModel.Crew1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew1NameText", crewsViewModel.Crew1.Name);
                crewsCssModel.Crew1.CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew1Character", crewsViewModel.Crew1.Character);
                crewsCssModel.Crew1.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew1Port", crewsViewModel.Crew1.Port);
                crewsCssModel.Crew1.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew1StocksLeftText", crewsViewModel.Crew1.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew1.Players.Count; i++)
                {
                    crewsCssModel.Crew1.CrewPlayerCssModels.Add(new CrewPlayerCssModel());

                    crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew1Player{i + 1}NameText", crewsViewModel.Crew1.Players[i].Name);
                    crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".crew1Player{i + 1}Active", crewsViewModel.Crew1.Players[i].Active.ToString());
                    crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".crew1Player{i + 1}Eliminated", crewsViewModel.Crew1.Players[i].Eliminated.ToString());                    

                    crewsCssModel.Crew1.CrewPlayerCssModels[i].Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew1Player{i + 1}TwitterText", crewsViewModel.Crew1.Players[i].Twitter);
                    crewsCssModel.Crew1.CrewPlayerCssModels[i].CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew1Player{i + 1}Character", crewsViewModel.Crew1.Players[i].Character);
                }

                crewsCssModel.Crew2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew2NameText", crewsViewModel.Crew2.Name);
                crewsCssModel.Crew2.CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew2Character", crewsViewModel.Crew2.Character);
                crewsCssModel.Crew2.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew2Port", crewsViewModel.Crew2.Port);
                crewsCssModel.Crew2.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#crew2StocksLeftText", crewsViewModel.Crew2.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew2.Players.Count; i++)
                {
                    crewsCssModel.Crew2.CrewPlayerCssModels.Add(new CrewPlayerCssModel());

                    crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name);
                    crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".crew2Player{i + 1}Active", crewsViewModel.Crew2.Players[i].Active.ToString());
                    crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".crew2Player{i + 1}Eliminated", crewsViewModel.Crew2.Players[i].Eliminated.ToString());

                    crewsCssModel.Crew2.CrewPlayerCssModels[i].Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew2Player{i + 1}TwitterText", crewsViewModel.Crew2.Players[i].Twitter);
                    crewsCssModel.Crew2.CrewPlayerCssModels[i].CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#crew2Player{i + 1}Character", crewsViewModel.Crew2.Players[i].Character);
                }

                crewsCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#tournamentText", crewsViewModel.Tournament);
                crewsCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#extraText", crewsViewModel.Extra);
                crewsCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#roundText", crewsViewModel.Round);
                crewsCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#bestOfText", crewsViewModel.BestOf);

                _smashFileWriter.WriteCrewsFile(crewsViewModel.PathToFormat, crewsCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateSquadStrikeOverlay(SquadStrikeViewModel squadStrikeViewModel)
        {
            try
            {
                var squadStrikeCssModel = new SquadStrikeCssModel();

                squadStrikeCssModel.Squad1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad1NameText", squadStrikeViewModel.Squad1.Name);
                squadStrikeCssModel.Squad1.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad1Port", squadStrikeViewModel.Squad1.Port);
                squadStrikeCssModel.Squad1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad1ScoreText", squadStrikeViewModel.Squad1.Score ?? "?");

                for (var i = 0; i < squadStrikeViewModel.Squad1.Players.Count; i++)
                {
                    squadStrikeCssModel.Squad1.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad1Player{i + 1}NameText", squadStrikeViewModel.Squad1.Players[i].Name);
                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".squad1Player{i + 1}Active", squadStrikeViewModel.Squad1.Players[i].Active.ToString());
                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad1Player{i + 1}TwitterText", squadStrikeViewModel.Squad1.Players[i].Twitter);
                    }

                    squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad1Character{i + 1}", squadStrikeViewModel.Squad1.Players[i].Character);
                    squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".squad1Character{i + 1}Eliminated", squadStrikeViewModel.Squad1.Players[i].Eliminated.ToString());
                }

                squadStrikeCssModel.Squad2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad2NameText", squadStrikeViewModel.Squad2.Name);
                squadStrikeCssModel.Squad2.PortPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad2Port", squadStrikeViewModel.Squad2.Port);
                squadStrikeCssModel.Squad2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#squad2ScoreText", squadStrikeViewModel.Squad2.Score ?? "?");

                for (var i = 0; i < squadStrikeViewModel.Squad2.Players.Count; i++)
                {
                    squadStrikeCssModel.Squad2.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad2Player{i + 1}NameText", squadStrikeViewModel.Squad2.Players[i].Name);
                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".squad2Player{i + 1}Active", squadStrikeViewModel.Squad2.Players[i].Active.ToString());
                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad2Player{i + 1}TwitterText", squadStrikeViewModel.Squad2.Players[i].Twitter);
                    }

                    squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"#squad2Character{i + 1}", squadStrikeViewModel.Squad2.Players[i].Character);
                    squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath += _textReplacer.ReplaceIdAndValue(_textTemplateJson, $".squad2Character{i + 1}Eliminated", squadStrikeViewModel.Squad2.Players[i].Eliminated.ToString());
                }

                squadStrikeCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#tournamentText", squadStrikeViewModel.Tournament);
                squadStrikeCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#extraText", squadStrikeViewModel.Extra);
                squadStrikeCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#roundText", squadStrikeViewModel.Round);
                squadStrikeCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateJson, "#bestOfText", squadStrikeViewModel.BestOf);

                _smashFileWriter.WriteSquadStrikeFile(squadStrikeViewModel.PathToFormat, squadStrikeCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}