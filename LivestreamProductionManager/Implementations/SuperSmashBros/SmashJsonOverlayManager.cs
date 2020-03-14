using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet;
using Serilog;
using System;
using System.Collections.Generic;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashJsonOverlayManager : ISmashOverlayManager
    {
        private readonly ISmashFileWriter _smashFileWriter = new SmashJsonFileWriter();

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
                    new SelectorValueModel("#player1Port", singlesViewModel.Player1.Port),
                    new SelectorValueModel("#player1Country", singlesViewModel.Player1.Country),

                    new SelectorValueModel("#player2NameText", singlesViewModel.Player2.Name),
                    new SelectorValueModel(".player2Sponsor", singlesViewModel.Player2.Sponsor),
                    new SelectorValueModel("#player2TwitterText", singlesViewModel.Player2.Twitter),
                    new SelectorValueModel("#player2TwitchText", singlesViewModel.Player2.Twitch),
                    new SelectorValueModel("#player2ScoreText", singlesViewModel.Player2.Score ?? "?"),
                    new SelectorValueModel("#player2Character", singlesViewModel.Player2.Character),
                    new SelectorValueModel("#player2Port", singlesViewModel.Player2.Port),
                    new SelectorValueModel("#player2Country", singlesViewModel.Player2.Country),

                    new SelectorValueModel("#tournamentText", singlesViewModel.Tournament),
                    new SelectorValueModel("#extraText", singlesViewModel.Extra),
                    new SelectorValueModel("#roundText", singlesViewModel.Round),
                    new SelectorValueModel("#bestOfText", singlesViewModel.BestOf)
                };

                _smashFileWriter.WriteJsonFile(singlesViewModel.PathToFormat, selectorValueModels);
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
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#team1NameText", doublesViewModel.Team1.Name),
                    new SelectorValueModel("#team1ScoreText", doublesViewModel.Team1.Score ?? "?")                   
                };

                for (var i = 0; i < doublesViewModel.Team1.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#team1Player{i + 1}NameText", doublesViewModel.Team1.Players[i].Name),
                            new SelectorValueModel($".team1Player{i + 1}Sponsor", doublesViewModel.Team1.Players[i].Sponsor),
                            new SelectorValueModel($"#team1Player{i + 1}Twitter", doublesViewModel.Team1.Players[i].Twitter),
                            new SelectorValueModel($"#team1Player{i + 1}Twitch", doublesViewModel.Team1.Players[i].Twitch),
                            new SelectorValueModel($"#team1Player{i + 1}Character", doublesViewModel.Team1.Players[i].Character),
                            new SelectorValueModel($"#team1Player{i + 1}Port", doublesViewModel.Team1.Players[i].Port),
                            new SelectorValueModel($"#team1Player{i + 1}Country", doublesViewModel.Team1.Players[i].Country)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#team2NameText", doublesViewModel.Team2.Name),
                        new SelectorValueModel("#team2ScoreText", doublesViewModel.Team2.Score ?? "?")
                    }
                );

                for (var i = 0; i < doublesViewModel.Team2.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#team2Player{i + 1}NameText", doublesViewModel.Team2.Players[i].Name),
                            new SelectorValueModel($".team2Player{i + 1}Sponsor", doublesViewModel.Team2.Players[i].Sponsor),
                            new SelectorValueModel($"#team2Player{i + 1}Twitter", doublesViewModel.Team2.Players[i].Twitter),
                            new SelectorValueModel($"#team2Player{i + 1}Twitch", doublesViewModel.Team2.Players[i].Twitch),
                            new SelectorValueModel($"#team2Player{i + 1}Character", doublesViewModel.Team2.Players[i].Character),
                            new SelectorValueModel($"#team2Player{i + 1}Port", doublesViewModel.Team2.Players[i].Port),
                            new SelectorValueModel($"#team2Player{i + 1}Country", doublesViewModel.Team2.Players[i].Country)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#tournamentText", doublesViewModel.Tournament),
                        new SelectorValueModel("#extraText", doublesViewModel.Extra),
                        new SelectorValueModel("#roundText", doublesViewModel.Round),
                        new SelectorValueModel("#bestOfText", doublesViewModel.BestOf)
                    }
                );

                _smashFileWriter.WriteJsonFile(doublesViewModel.PathToFormat, selectorValueModels);
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
                    new SelectorValueModel("#crew1Port", crewsViewModel.Crew1.Port),
                    new SelectorValueModel("#crew1Country", crewsViewModel.Crew1.Country),
                    new SelectorValueModel("#crew1StocksLeftText", crewsViewModel.Crew1.StocksLeft ?? "?")
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
                        new SelectorValueModel("#crew2Port", crewsViewModel.Crew2.Port),
                        new SelectorValueModel("#crew2Country", crewsViewModel.Crew2.Country),
                        new SelectorValueModel("#crew2StocksLeftText", crewsViewModel.Crew2.StocksLeft ?? "?")
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

                _smashFileWriter.WriteJsonFile(crewsViewModel.PathToFormat, selectorValueModels);
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
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#squad1NameText", squadStrikeViewModel.Squad1.Name),
                    new SelectorValueModel("#squad1Port", squadStrikeViewModel.Squad1.Port),
                    new SelectorValueModel("#squad1Country", squadStrikeViewModel.Squad1.Country),
                    new SelectorValueModel("#squad1ScoreText", squadStrikeViewModel.Squad1.Score ?? "?")
                };

                for (var i = 0; i < squadStrikeViewModel.Squad1.Players.Count; i++)
                {
                    if (i < 4)
                    {
                        selectorValueModels.AddRange
                        (
                            new List<SelectorValueModel>
                            {
                                new SelectorValueModel($"#squad1Player{i + 1}NameText", squadStrikeViewModel.Squad1.Players[i].Name),
                                new SelectorValueModel($".squad1Player{i + 1}Active", squadStrikeViewModel.Squad1.Players[i].Active.ToString()),
                                new SelectorValueModel($"#squad1Player{i + 1}TwitterText", squadStrikeViewModel.Squad1.Players[i].Twitter)
                            }
                        );
                    }

                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#squad1Character{i + 1}", squadStrikeViewModel.Squad1.Players[i].Character),
                            new SelectorValueModel($".squad1Character{i + 1}Eliminated", squadStrikeViewModel.Squad1.Players[i].Eliminated.ToString())
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel> {
                        new SelectorValueModel("#squad2NameText", squadStrikeViewModel.Squad2.Name),
                        new SelectorValueModel("#squad2Port", squadStrikeViewModel.Squad2.Port),
                        new SelectorValueModel("#squad2Country", squadStrikeViewModel.Squad2.Country),
                        new SelectorValueModel("#squad2ScoreText", squadStrikeViewModel.Squad2.Score ?? "?")
                    }
                );

                for (var i = 0; i < squadStrikeViewModel.Squad2.Players.Count; i++)
                {
                    if (i < 4)
                    {
                        selectorValueModels.AddRange
                        (
                            new List<SelectorValueModel>
                            {
                                new SelectorValueModel($"#squad2Player{i + 1}NameText", squadStrikeViewModel.Squad2.Players[i].Name),
                                new SelectorValueModel($".squad2Player{i + 1}Active", squadStrikeViewModel.Squad2.Players[i].Active.ToString()),
                                new SelectorValueModel($"#squad2Player{i + 1}TwitterText", squadStrikeViewModel.Squad2.Players[i].Twitter)
                            }
                        );
                    }

                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#squad2Character{i + 1}", squadStrikeViewModel.Squad2.Players[i].Character),
                            new SelectorValueModel($".squad2Character{i + 1}Eliminated", squadStrikeViewModel.Squad2.Players[i].Eliminated.ToString())
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#tournamentText", squadStrikeViewModel.Tournament),
                        new SelectorValueModel("#extraText", squadStrikeViewModel.Extra),
                        new SelectorValueModel("#roundText", squadStrikeViewModel.Round),
                        new SelectorValueModel("#bestOfText", squadStrikeViewModel.BestOf)
                    }
                );

                _smashFileWriter.WriteJsonFile(squadStrikeViewModel.PathToFormat, selectorValueModels);
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
                    new SelectorValueModel("#player1Port", singlesNextSetViewModel.Player1.Port),

                    new SelectorValueModel("#player2NameText", singlesNextSetViewModel.Player2.Name),
                    new SelectorValueModel(".player2Sponsor", singlesNextSetViewModel.Player2.Sponsor),
                    new SelectorValueModel("#player2TwitterText", singlesNextSetViewModel.Player2.Twitter),
                    new SelectorValueModel("#player2TwitchText", singlesNextSetViewModel.Player2.Twitch),
                    new SelectorValueModel("#player2Character", singlesNextSetViewModel.Player2.Character),
                    new SelectorValueModel("#player2Port", singlesNextSetViewModel.Player2.Port),

                    new SelectorValueModel("#roundText", singlesNextSetViewModel.Round),
                    new SelectorValueModel("#bestOfText", singlesNextSetViewModel.BestOf)
                };

                _smashFileWriter.WriteJsonFile(singlesNextSetViewModel.PathToFormatNextSet, selectorValueModels);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateDoublesNextSetOverlay(DoublesNextSetViewModel doublesNextSetViewModel)
        {
            try
            {
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#team1NameText", doublesNextSetViewModel.Team1.Name)
                };

                for (var i = 0; i < doublesNextSetViewModel.Team1.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#team1Player{i + 1}NameText", doublesNextSetViewModel.Team1.Players[i].Name),
                            new SelectorValueModel($".team1Player{i + 1}Sponsor", doublesNextSetViewModel.Team1.Players[i].Sponsor),
                            new SelectorValueModel($"#team1Player{i + 1}Twitter", doublesNextSetViewModel.Team1.Players[i].Twitter),
                            new SelectorValueModel($"#team1Player{i + 1}Twitch", doublesNextSetViewModel.Team1.Players[i].Twitch),
                            new SelectorValueModel($"#team1Player{i + 1}Character", doublesNextSetViewModel.Team1.Players[i].Character),
                            new SelectorValueModel($"#team1Player{i + 1}Port", doublesNextSetViewModel.Team1.Players[i].Port)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#team2NameText", doublesNextSetViewModel.Team2.Name),
                    }
                );

                for (var i = 0; i < doublesNextSetViewModel.Team2.Players.Count; i++)
                {
                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#team2Player{i + 1}NameText", doublesNextSetViewModel.Team2.Players[i].Name),
                            new SelectorValueModel($".team2Player{i + 1}Sponsor", doublesNextSetViewModel.Team2.Players[i].Sponsor),
                            new SelectorValueModel($"#team2Player{i + 1}Twitter", doublesNextSetViewModel.Team2.Players[i].Twitter),
                            new SelectorValueModel($"#team2Player{i + 1}Twitch", doublesNextSetViewModel.Team2.Players[i].Twitch),
                            new SelectorValueModel($"#team2Player{i + 1}Character", doublesNextSetViewModel.Team2.Players[i].Character),
                            new SelectorValueModel($"#team2Player{i + 1}Port", doublesNextSetViewModel.Team2.Players[i].Port)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#roundText", doublesNextSetViewModel.Round),
                        new SelectorValueModel("#bestOfText", doublesNextSetViewModel.BestOf)
                    }
                );

                _smashFileWriter.WriteJsonFile(doublesNextSetViewModel.PathToFormatNextSet, selectorValueModels);
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
                    new SelectorValueModel("#crew1Port", crewsNextSetViewModel.Crew1.Port),
                    new SelectorValueModel("#crew1StocksLeftText", crewsNextSetViewModel.Crew1.StocksLeft ?? "?")
                };

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#crew2NameText", crewsNextSetViewModel.Crew2.Name),
                        new SelectorValueModel("#crew2Character", crewsNextSetViewModel.Crew2.Character),
                        new SelectorValueModel("#crew2Port", crewsNextSetViewModel.Crew2.Port),
                        new SelectorValueModel("#crew2StocksLeftText", crewsNextSetViewModel.Crew2.StocksLeft ?? "?")
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

                _smashFileWriter.WriteJsonFile(crewsNextSetViewModel.PathToFormatNextSet, selectorValueModels);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        public void UpdateSquadStrikeNextSetOverlay(SquadStrikeNextSetViewModel squadStrikeNextSetViewModel)
        {
            try
            {
                var selectorValueModels = new List<SelectorValueModel>
                {
                    new SelectorValueModel("#squad1NameText", squadStrikeNextSetViewModel.Squad1.Name),
                    new SelectorValueModel("#squad1Port", squadStrikeNextSetViewModel.Squad1.Port)
                };

                for (var i = 0; i < squadStrikeNextSetViewModel.Squad1.Players.Count; i++)
                {
                    if (i < 4)
                    {
                        selectorValueModels.AddRange
                        (
                            new List<SelectorValueModel>
                            {
                                new SelectorValueModel($"#squad1Player{i + 1}NameText", squadStrikeNextSetViewModel.Squad1.Players[i].Name),
                                new SelectorValueModel($"#squad1Player{i + 1}TwitterText", squadStrikeNextSetViewModel.Squad1.Players[i].Twitter)
                            }
                        );
                    }

                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#squad1Character{i + 1}", squadStrikeNextSetViewModel.Squad1.Players[i].Character)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel> {
                        new SelectorValueModel("#squad2NameText", squadStrikeNextSetViewModel.Squad2.Name),
                        new SelectorValueModel("#squad2Port", squadStrikeNextSetViewModel.Squad2.Port)
                    }
                );

                for (var i = 0; i < squadStrikeNextSetViewModel.Squad2.Players.Count; i++)
                {
                    if (i < 4)
                    {
                        selectorValueModels.AddRange
                        (
                            new List<SelectorValueModel>
                            {
                                new SelectorValueModel($"#squad2Player{i + 1}NameText", squadStrikeNextSetViewModel.Squad2.Players[i].Name),
                                new SelectorValueModel($"#squad2Player{i + 1}TwitterText", squadStrikeNextSetViewModel.Squad2.Players[i].Twitter)
                            }
                        );
                    }

                    selectorValueModels.AddRange
                    (
                        new List<SelectorValueModel>
                        {
                            new SelectorValueModel($"#squad2Character{i + 1}", squadStrikeNextSetViewModel.Squad2.Players[i].Character)
                        }
                    );
                }

                selectorValueModels.AddRange
                (
                    new List<SelectorValueModel>
                    {
                        new SelectorValueModel("#roundText", squadStrikeNextSetViewModel.Round),
                        new SelectorValueModel("#bestOfText", squadStrikeNextSetViewModel.BestOf)
                    }
                );

                _smashFileWriter.WriteJsonFile(squadStrikeNextSetViewModel.PathToFormatNextSet, selectorValueModels);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}