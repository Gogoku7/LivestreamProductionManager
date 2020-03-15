using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.TraditionalFG;
using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.Models.FightingGames.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG.NewSet;
using Serilog;
using System;
using System.Collections.Generic;

namespace LivestreamProductionManager.Implementations.TraditionalFG
{
    public class TraditionalFGJsonOverlayManager : ITraditionalFGOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/JsonTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ITraditionalFGFileWriter _traditionalWriter = new TraditionalFGJsonFileWriter();

        private readonly string _textTemplateJson;

        public TraditionalFGJsonOverlayManager()
        {
            _textTemplateJson = _templatefileReader.ReadTemplateFile("TextTemplateFile.json");
        }

        public void UpdateSinglesOverlay(SinglesViewModel singlesViewModel)
        {
            try
            {
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#player1NameText", singlesViewModel.Player1.Name),
                    new SelectorValueModel(".player1Sponsor", singlesViewModel.Player1.Sponsor),
                    new SelectorValueModel("#player1TwitterText", singlesViewModel.Player1.Twitter),
                    new SelectorValueModel("#player1TwitchText", singlesViewModel.Player1.Twitch),
                    new SelectorValueModel("#player1ScoreText", singlesViewModel.Player1.Score ?? "?"),
                    new SelectorValueModel("#player1Character", singlesViewModel.Player1.Character),
                    new SelectorValueModel("#player1Country", singlesViewModel.Player1.Country),

                    new SelectorValueModel("#player2NameText", singlesViewModel.Player2.Name),
                    new SelectorValueModel(".player2Sponsor", singlesViewModel.Player2.Sponsor),
                    new SelectorValueModel("#player2TwitterText", singlesViewModel.Player2.Twitter),
                    new SelectorValueModel("#player2TwitchText", singlesViewModel.Player2.Twitch),
                    new SelectorValueModel("#player2ScoreText", singlesViewModel.Player2.Score ?? "?"),
                    new SelectorValueModel("#player2Character", singlesViewModel.Player2.Character),
                    new SelectorValueModel("#player2Country", singlesViewModel.Player2.Country),

                    new SelectorValueModel("#tournamentText", singlesViewModel.Tournament),
                    new SelectorValueModel("#extraText", singlesViewModel.Extra),
                    new SelectorValueModel("#roundText", singlesViewModel.Round),
                    new SelectorValueModel("#bestOfText", singlesViewModel.BestOf)
                };

                _traditionalWriter.WriteJsonFile(singlesViewModel.PathToFormat, selectorValueModels);
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
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#crew1NameText", crewsViewModel.Crew1.Name),
                    new SelectorValueModel("#crew1Character", crewsViewModel.Crew1.Character),
                    new SelectorValueModel("#crew1Country", crewsViewModel.Crew1.Country),
                    new SelectorValueModel("#crew1ScoreText", crewsViewModel.Crew1.Score ?? "?")
                };

                for (var i = 0; i < crewsViewModel.Crew1.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#crew1Player{i + 1}NameText", crewsViewModel.Crew1.Players[i].Name),
                            new SelectorValueModel($".crew1Player{i + 1}Active", crewsViewModel.Crew1.Players[i].Active.ToString()),
                            new SelectorValueModel($".crew1Player{i + 1}Eliminated", crewsViewModel.Crew1.Players[i].Eliminated.ToString()),
                            new SelectorValueModel($"#crew1Player{i + 1}TwitterText", crewsViewModel.Crew1.Players[i].Twitter),
                            new SelectorValueModel($"#crew1Player{i + 1}Character", crewsViewModel.Crew1.Players[i].Character)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#crew2NameText", crewsViewModel.Crew2.Name),
                        new SelectorValueModel("#crew2Character", crewsViewModel.Crew2.Character),
                        new SelectorValueModel("#crew2Country", crewsViewModel.Crew2.Country),
                        new SelectorValueModel("#crew2ScoreText", crewsViewModel.Crew2.Score ?? "?")
                    }
                );

                for (var i = 0; i < crewsViewModel.Crew2.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name),
                            new SelectorValueModel($".crew2Player{i + 1}Active", crewsViewModel.Crew2.Players[i].Active.ToString()),
                            new SelectorValueModel($".crew2Player{i + 1}Eliminated", crewsViewModel.Crew2.Players[i].Eliminated.ToString()),
                            new SelectorValueModel($"#crew2Player{i + 1}TwitterText", crewsViewModel.Crew2.Players[i].Twitter),
                            new SelectorValueModel($"#crew2Player{i + 1}Character", crewsViewModel.Crew2.Players[i].Character)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#tournamentText", crewsViewModel.Tournament),
                        new SelectorValueModel("#extraText", crewsViewModel.Extra),
                        new SelectorValueModel("#roundText", crewsViewModel.Round),
                        new SelectorValueModel("#bestOfText", crewsViewModel.BestOf)
                    }
                );

                _traditionalWriter.WriteJsonFile(crewsViewModel.PathToFormat, selectorValueModels);
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
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#player1NameText", singlesNextSetViewModel.Player1.Name),
                    new SelectorValueModel(".player1Sponsor", singlesNextSetViewModel.Player1.Sponsor),
                    new SelectorValueModel("#player1TwitterText", singlesNextSetViewModel.Player1.Twitter),
                    new SelectorValueModel("#player1TwitchText", singlesNextSetViewModel.Player1.Twitch),
                    new SelectorValueModel("#player1Character", singlesNextSetViewModel.Player1.Character),
                    new SelectorValueModel("#player1Country", singlesNextSetViewModel.Player1.Country),

                    new SelectorValueModel("#player2NameText", singlesNextSetViewModel.Player2.Name),
                    new SelectorValueModel(".player2Sponsor", singlesNextSetViewModel.Player2.Sponsor),
                    new SelectorValueModel("#player2TwitterText", singlesNextSetViewModel.Player2.Twitter),
                    new SelectorValueModel("#player2TwitchText", singlesNextSetViewModel.Player2.Twitch),
                    new SelectorValueModel("#player2Character", singlesNextSetViewModel.Player2.Character),
                    new SelectorValueModel("#player2Country", singlesNextSetViewModel.Player2.Country),

                    new SelectorValueModel("#roundText", singlesNextSetViewModel.Round),
                    new SelectorValueModel("#bestOfText", singlesNextSetViewModel.BestOf)
                };

                _traditionalWriter.WriteJsonFile(singlesNextSetViewModel.PathToFormatNextSet, selectorValueModels);
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
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#crew1NameText", crewsNextSetViewModel.Crew1.Name),
                    new SelectorValueModel("#crew1Character", crewsNextSetViewModel.Crew1.Character),
                    new SelectorValueModel("#crew1Country", crewsNextSetViewModel.Crew1.Character),
                    new SelectorValueModel("#crew1ScoreText", crewsNextSetViewModel.Crew1.Score ?? "?")
                };

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#crew2NameText", crewsNextSetViewModel.Crew2.Name),
                        new SelectorValueModel("#crew2Character", crewsNextSetViewModel.Crew2.Character),
                        new SelectorValueModel("#crew2Country", crewsNextSetViewModel.Crew2.Country),
                        new SelectorValueModel("#crew2ScoreText", crewsNextSetViewModel.Crew2.Score ?? "?")
                    }
                );

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#roundText", crewsNextSetViewModel.Round),
                        new SelectorValueModel("#bestOfText", crewsNextSetViewModel.BestOf)
                    }
                );

                _traditionalWriter.WriteJsonFile(crewsNextSetViewModel.PathToFormatNextSet, selectorValueModels);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}