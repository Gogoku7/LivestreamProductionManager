using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG.NextSet;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG.NewSet;
using Serilog;
using System;

namespace LivestreamProductionManager.Implementations.TraditionalFG
{
    public class TraditionalFGCssOverlayManager : ITraditionalFGOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ITraditionalFGFileWriter _traditionalFGCssFileWriter = new TraditionalFGCssFileWriter();

        private readonly string _textTemplateCss;
        private readonly string _imageTemplateCss;
        private readonly string _crewPlayerActiveTemplateCss;
        private readonly string _crewPlayerEliminatedTemplateCss;

        public TraditionalFGCssOverlayManager()
        {
            _textTemplateCss = _templatefileReader.ReadTemplateFile("TextTemplateFile.css");
            _imageTemplateCss = _templatefileReader.ReadTemplateFile("ImageTemplateFile.css");
            _crewPlayerActiveTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerActiveTemplateFile.css");
            _crewPlayerEliminatedTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerEliminatedTemplateFile.css");
        }

        public void UpdateSinglesOverlay(SinglesViewModel singlesViewModel)
        {
            try
            {
                var singlesCssModel = new SinglesCssModel();
                singlesCssModel.Player1.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player1NameText", singlesViewModel.Player1.Sponsor, singlesViewModel.Player1.Name);
                singlesCssModel.Player1.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1TwitterText", singlesViewModel.Player1.Twitter);
                singlesCssModel.Player1.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1TwitchText", singlesViewModel.Player1.Twitch);
                singlesCssModel.Player1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1ScoreText", singlesViewModel.Player1.Score ?? "?");
                singlesCssModel.Player1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Character", singlesViewModel.Player1.Character);
                singlesCssModel.Player1.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Country", singlesViewModel.Player1.Country);

                singlesCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player2NameText", singlesViewModel.Player2.Sponsor, singlesViewModel.Player2.Name);
                singlesCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitterText", singlesViewModel.Player2.Twitter);
                singlesCssModel.Player2.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitchText", singlesViewModel.Player2.Twitch);
                singlesCssModel.Player2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2ScoreText", singlesViewModel.Player2.Score ?? "?");
                singlesCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Character", singlesViewModel.Player2.Character);
                singlesCssModel.Player2.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Country", singlesViewModel.Player2.Country);

                singlesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", singlesViewModel.Tournament);
                singlesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", singlesViewModel.Extra);
                singlesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", singlesViewModel.Round);
                singlesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", singlesViewModel.BestOf);

                _traditionalFGCssFileWriter.WriteSinglesFile(singlesViewModel.PathToFormat, singlesCssModel);
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

                crewsCssModel.Crew1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1NameText", crewsViewModel.Crew1.Name);
                crewsCssModel.Crew1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Character", crewsViewModel.Crew1.Character);
                crewsCssModel.Crew1.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1StocksLeftText", crewsViewModel.Crew1.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew1.Players.Count; i++)
                {
                    crewsCssModel.Crew1.CrewPlayerCssModels.Add(new CrewPlayerCssModel());

                    if (crewsViewModel.Crew1.Players[i].Active)
                    {
                        crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_crewPlayerActiveTemplateCss, $"crew1Player{i + 1}NameText", crewsViewModel.Crew1.Players[i].Name) }\r\n";
                    }
                    else if (crewsViewModel.Crew1.Players[i].Eliminated)
                    {
                        crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_crewPlayerEliminatedTemplateCss, $"crew1Player{i + 1}NameText", crewsViewModel.Crew1.Players[i].Name) }\r\n";
                    }
                    else
                    {
                        crewsCssModel.Crew1.CrewPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew1Player{i + 1}NameText", crewsViewModel.Crew1.Players[i].Name) }\r\n";
                    }

                    crewsCssModel.Crew1.CrewPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew1Player{i + 1}TwitterText", crewsViewModel.Crew1.Players[i].Twitter) }\r\n";
                    crewsCssModel.Crew1.CrewPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"crew1Player{i + 1}Character", crewsViewModel.Crew1.Players[i].Character) }\r\n";
                }

                crewsCssModel.Crew2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2NameText", crewsViewModel.Crew2.Name);
                crewsCssModel.Crew2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Character", crewsViewModel.Crew2.Character);
                crewsCssModel.Crew2.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2StocksLeftText", crewsViewModel.Crew2.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew2.Players.Count; i++)
                {
                    crewsCssModel.Crew2.CrewPlayerCssModels.Add(new CrewPlayerCssModel());

                    if (crewsViewModel.Crew2.Players[i].Active)
                    {
                        crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_crewPlayerActiveTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) }\r\n";
                    }
                    else if (crewsViewModel.Crew2.Players[i].Eliminated)
                    {
                        crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_crewPlayerEliminatedTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) }\r\n";
                    }
                    else
                    {
                        crewsCssModel.Crew2.CrewPlayerCssModels[i].NameAndSponsor = $"{_textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) }\r\n";
                    }

                    crewsCssModel.Crew2.CrewPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew2Player{i + 1}TwitterText", crewsViewModel.Crew2.Players[i].Twitter) }\r\n";
                    crewsCssModel.Crew2.CrewPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"crew2Player{i + 1}Character", crewsViewModel.Crew2.Players[i].Character) }\r\n";
                }

                crewsCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", crewsViewModel.Tournament);
                crewsCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", crewsViewModel.Extra);
                crewsCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", crewsViewModel.Round);
                crewsCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", crewsViewModel.BestOf);

                _traditionalFGCssFileWriter.WriteCrewsFile(crewsViewModel.PathToFormat, crewsCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateSinglesNextSetOverlay(SinglesNextSetViewModel singlesNextSetViewModel)
        {
            try
            {
                var singlesNextSetCssModel = new SinglesNextSetCssModel();
                singlesNextSetCssModel.Player1.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player1NameText", singlesNextSetViewModel.Player1.Sponsor, singlesNextSetViewModel.Player1.Name);
                singlesNextSetCssModel.Player1.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1TwitterText", singlesNextSetViewModel.Player1.Twitter);
                singlesNextSetCssModel.Player1.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1TwitchText", singlesNextSetViewModel.Player1.Twitch);
                singlesNextSetCssModel.Player1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Character", singlesNextSetViewModel.Player1.Character);

                singlesNextSetCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player2NameText", singlesNextSetViewModel.Player2.Sponsor, singlesNextSetViewModel.Player2.Name);
                singlesNextSetCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitterText", singlesNextSetViewModel.Player2.Twitter);
                singlesNextSetCssModel.Player2.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitchText", singlesNextSetViewModel.Player2.Twitch);
                singlesNextSetCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Character", singlesNextSetViewModel.Player2.Character);

                singlesNextSetCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", singlesNextSetViewModel.Round);
                singlesNextSetCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", singlesNextSetViewModel.BestOf);

                _traditionalFGCssFileWriter.WriteSinglesNextSetFile(singlesNextSetViewModel.PathToFormatNextSet, singlesNextSetCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateCrewsNextSetOverlay(CrewsNextSetViewModel crewsNextSetViewModel)
        {
            try
            {
                var crewsNextSetCssModel = new CrewsNextSetCssModel();

                crewsNextSetCssModel.Crew1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1NameText", crewsNextSetViewModel.Crew1.Name);
                crewsNextSetCssModel.Crew1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Character", crewsNextSetViewModel.Crew1.Character);
                crewsNextSetCssModel.Crew1.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1StocksLeftText", crewsNextSetViewModel.Crew1.StocksLeft ?? "?");

                crewsNextSetCssModel.Crew2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2NameText", crewsNextSetViewModel.Crew2.Name);
                crewsNextSetCssModel.Crew2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Character", crewsNextSetViewModel.Crew2.Character);
                crewsNextSetCssModel.Crew2.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2StocksLeftText", crewsNextSetViewModel.Crew2.StocksLeft ?? "?");

                crewsNextSetCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", crewsNextSetViewModel.Round);
                crewsNextSetCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", crewsNextSetViewModel.BestOf);

                _traditionalFGCssFileWriter.WriteCrewsNextSetFile(crewsNextSetViewModel.PathToFormatNextSet, crewsNextSetCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}