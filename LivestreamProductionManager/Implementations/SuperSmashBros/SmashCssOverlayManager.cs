using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros.NextSet;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros.NextSet;
using Serilog;
using System;
using System.Linq;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashCssOverlayManager : ISmashOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ISmashFileWriter _smashFileWriter = new SmashCssFileWriter();

        private readonly string _textTemplateCss;
        private readonly string _imageTemplateCss;
        private readonly string _crewPlayerActiveTemplateCss;
        private readonly string _crewPlayerEliminatedTemplateCss;
        private readonly string _squadPlayerActiveTemplateCss;
        private readonly string _squadCharacterEliminatedTemplateCss;

        public SmashCssOverlayManager()
        {
            _textTemplateCss = _templatefileReader.ReadTemplateFile("TextTemplateFile.css");
            _imageTemplateCss = _templatefileReader.ReadTemplateFile("ImageTemplateFile.css");
            _crewPlayerActiveTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerActiveTemplateFile.css");
            _crewPlayerEliminatedTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerEliminatedTemplateFile.css");
            _squadPlayerActiveTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerActiveTemplateFile.css");
            _squadCharacterEliminatedTemplateCss = _templatefileReader.ReadTemplateFile("SquadCharacterEliminatedTemplateFile.css");
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
                singlesCssModel.Player1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Port", singlesViewModel.Player1.Port);
                singlesCssModel.Player1.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Country", singlesViewModel.Player1.Country);

                singlesCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player2NameText", singlesViewModel.Player2.Sponsor, singlesViewModel.Player2.Name);
                singlesCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitterText", singlesViewModel.Player2.Twitter);
                singlesCssModel.Player2.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitchText", singlesViewModel.Player2.Twitch);
                singlesCssModel.Player2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2ScoreText", singlesViewModel.Player2.Score ?? "?");
                singlesCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Character", singlesViewModel.Player2.Character);
                singlesCssModel.Player2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Port", singlesViewModel.Player2.Port);
                singlesCssModel.Player2.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Country", singlesViewModel.Player2.Country);

                singlesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", singlesViewModel.Tournament);
                singlesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", singlesViewModel.Extra);
                singlesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", singlesViewModel.Round);
                singlesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", singlesViewModel.BestOf);

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

                doublesCssModel.Team1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team1NameText", doublesViewModel.Team1.Name);
                doublesCssModel.Team1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team1ScoreText", doublesViewModel.Team1.Score ?? "?");
                doublesCssModel.Team1.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team1Player*NameText", doublesViewModel.Team1.Players.Select(p => p.Sponsor).ToList(), doublesViewModel.Team1.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team1.Twitters = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team1Player*TwitterText", doublesViewModel.Team1.Players.Select(p => p.Twitter).ToList());
                doublesCssModel.Team1.Twitches = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team1Player*TwitchText", doublesViewModel.Team1.Players.Select(p => p.Twitch).ToList());
                doublesCssModel.Team1.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Character", doublesViewModel.Team1.Players.Select(p => p.Character).ToList());
                doublesCssModel.Team1.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Port", doublesViewModel.Team1.Players.Select(p => p.Port).ToList());
                doublesCssModel.Team1.CountryPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Country", doublesViewModel.Team1.Players.Select(p => p.Country).ToList());

                doublesCssModel.Team2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team2NameText", doublesViewModel.Team2.Name);
                doublesCssModel.Team2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team2ScoreText", doublesViewModel.Team2.Score ?? "?");
                doublesCssModel.Team2.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team2Player*NameText", doublesViewModel.Team2.Players.Select(p => p.Sponsor).ToList(), doublesViewModel.Team2.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team2.Twitters = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team2Player*TwitterText", doublesViewModel.Team2.Players.Select(p => p.Twitter).ToList());
                doublesCssModel.Team2.Twitches = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team2Player*TwitchText", doublesViewModel.Team2.Players.Select(p => p.Twitch).ToList());
                doublesCssModel.Team2.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Character", doublesViewModel.Team2.Players.Select(p => p.Character).ToList());
                doublesCssModel.Team2.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Port", doublesViewModel.Team2.Players.Select(p => p.Port).ToList());
                doublesCssModel.Team2.CountryPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Country", doublesViewModel.Team2.Players.Select(p => p.Country).ToList());

                doublesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", doublesViewModel.Tournament);
                doublesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", doublesViewModel.Extra);
                doublesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", doublesViewModel.Round);
                doublesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", doublesViewModel.BestOf);

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

                crewsCssModel.Crew1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1NameText", crewsViewModel.Crew1.Name );
                crewsCssModel.Crew1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Character", crewsViewModel.Crew1.Character);
                crewsCssModel.Crew1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Port", crewsViewModel.Crew1.Port);
                crewsCssModel.Crew1.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Country", crewsViewModel.Crew1.Country);
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
                crewsCssModel.Crew2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Port", crewsViewModel.Crew2.Port);
                crewsCssModel.Crew2.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Country", crewsViewModel.Crew2.Country);
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

                squadStrikeCssModel.Squad1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad1NameText", squadStrikeViewModel.Squad1.Name);
                squadStrikeCssModel.Squad1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad1Port", squadStrikeViewModel.Squad1.Port);
                squadStrikeCssModel.Squad1.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad1Country", squadStrikeViewModel.Squad1.Country);
                squadStrikeCssModel.Squad1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad1ScoreText", squadStrikeViewModel.Squad1.Score ?? "?");

                for (var i = 0; i < squadStrikeViewModel.Squad1.Players.Count; i++)
                {
                    squadStrikeCssModel.Squad1.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        if (squadStrikeViewModel.Squad1.Players[i].Active)
                        {
                            squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_squadPlayerActiveTemplateCss, $"squad1Player{i + 1}NameText", squadStrikeViewModel.Squad1.Players[i].Name) }\r\n";
                        }
                        else
                        {
                            squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad1Player{i + 1}NameText", squadStrikeViewModel.Squad1.Players[i].Name) }\r\n";
                        }

                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad1Player{i + 1}TwitterText", squadStrikeViewModel.Squad1.Players[i].Twitter) }\r\n";
                    }

                    if (squadStrikeViewModel.Squad1.Players[i].Eliminated)
                    {
                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_squadCharacterEliminatedTemplateCss, $"squad1Character{i + 1}", squadStrikeViewModel.Squad1.Players[i].Character) }\r\n";
                    }
                    else
                    {
                        squadStrikeCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"squad1Character{i + 1}", squadStrikeViewModel.Squad1.Players[i].Character) }\r\n";
                    }
                }

                squadStrikeCssModel.Squad2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad2NameText", squadStrikeViewModel.Squad2.Name);
                squadStrikeCssModel.Squad2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad2Port", squadStrikeViewModel.Squad2.Port);
                squadStrikeCssModel.Squad2.CountryPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad2Country", squadStrikeViewModel.Squad2.Country);
                squadStrikeCssModel.Squad2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad2ScoreText", squadStrikeViewModel.Squad2.Score ?? "?");

                for (var i = 0; i < squadStrikeViewModel.Squad2.Players.Count; i++)
                {
                    squadStrikeCssModel.Squad2.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        if (squadStrikeViewModel.Squad2.Players[i].Active)
                        {
                            squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_squadPlayerActiveTemplateCss, $"squad2Player{i + 1}NameText", squadStrikeViewModel.Squad2.Players[i].Name) }\r\n";
                        }
                        else
                        {
                            squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad2Player{i + 1}NameText", squadStrikeViewModel.Squad2.Players[i].Name) }\r\n";
                        }

                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad2Player{i + 1}TwitterText", squadStrikeViewModel.Squad2.Players[i].Twitter) }\r\n";
                    }

                    if (squadStrikeViewModel.Squad2.Players[i].Eliminated)
                    {
                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_squadCharacterEliminatedTemplateCss, $"squad2Character{i + 1}", squadStrikeViewModel.Squad2.Players[i].Character) }\r\n";
                    }
                    else
                    {
                        squadStrikeCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"squad2Character{i + 1}", squadStrikeViewModel.Squad2.Players[i].Character) }\r\n";
                    }
                }

                squadStrikeCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", squadStrikeViewModel.Tournament);
                squadStrikeCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", squadStrikeViewModel.Extra);
                squadStrikeCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", squadStrikeViewModel.Round);
                squadStrikeCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", squadStrikeViewModel.BestOf);

                _smashFileWriter.WriteSquadStrikeFile(squadStrikeViewModel.PathToFormat, squadStrikeCssModel);
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
                singlesNextSetCssModel.Player1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Port", singlesNextSetViewModel.Player1.Port);

                singlesNextSetCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player2NameText", singlesNextSetViewModel.Player2.Sponsor, singlesNextSetViewModel.Player2.Name);
                singlesNextSetCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitterText", singlesNextSetViewModel.Player2.Twitter);
                singlesNextSetCssModel.Player2.Twitch = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitchText", singlesNextSetViewModel.Player2.Twitch);
                singlesNextSetCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Character", singlesNextSetViewModel.Player2.Character);
                singlesNextSetCssModel.Player2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Port", singlesNextSetViewModel.Player2.Port);

                singlesNextSetCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", singlesNextSetViewModel.Round);
                singlesNextSetCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", singlesNextSetViewModel.BestOf);

                _smashFileWriter.WriteSinglesNextSetFile(singlesNextSetViewModel.PathToFormatNextSet, singlesNextSetCssModel);
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
                var doublesCssModel = new DoublesNextSetCssModel();

                doublesCssModel.Team1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team1NameText", doublesNextSetViewModel.Team1.Name);
                doublesCssModel.Team1.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team1Player*NameText", doublesNextSetViewModel.Team1.Players.Select(p => p.Sponsor).ToList(), doublesNextSetViewModel.Team1.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team1.Twitters = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team1Player*TwitterText", doublesNextSetViewModel.Team1.Players.Select(p => p.Twitter).ToList());
                doublesCssModel.Team1.Twitches = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team1Player*TwitchText", doublesNextSetViewModel.Team1.Players.Select(p => p.Twitch).ToList());
                doublesCssModel.Team1.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Character", doublesNextSetViewModel.Team1.Players.Select(p => p.Character).ToList());
                doublesCssModel.Team1.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Port", doublesNextSetViewModel.Team1.Players.Select(p => p.Port).ToList());

                doublesCssModel.Team2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team2NameText", doublesNextSetViewModel.Team2.Name);
                doublesCssModel.Team2.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team2Player*NameText", doublesNextSetViewModel.Team2.Players.Select(p => p.Sponsor).ToList(), doublesNextSetViewModel.Team2.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team2.Twitters = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team2Player*TwitterText", doublesNextSetViewModel.Team2.Players.Select(p => p.Twitter).ToList());
                doublesCssModel.Team2.Twitches = _textReplacer.ReplaceIdAndValueForTeam(_textTemplateCss, "team2Player*TwitchText", doublesNextSetViewModel.Team2.Players.Select(p => p.Twitch).ToList());
                doublesCssModel.Team2.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Character", doublesNextSetViewModel.Team2.Players.Select(p => p.Character).ToList());
                doublesCssModel.Team2.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Port", doublesNextSetViewModel.Team2.Players.Select(p => p.Port).ToList());

                doublesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", doublesNextSetViewModel.Round);
                doublesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", doublesNextSetViewModel.BestOf);

                _smashFileWriter.WriteDoublesNextSetFile(doublesNextSetViewModel.PathToFormatNextSet, doublesCssModel);
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
                crewsNextSetCssModel.Crew1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Port", crewsNextSetViewModel.Crew1.Port);
                crewsNextSetCssModel.Crew1.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1StocksLeftText", crewsNextSetViewModel.Crew1.StocksLeft ?? "?");

                crewsNextSetCssModel.Crew2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2NameText", crewsNextSetViewModel.Crew2.Name);
                crewsNextSetCssModel.Crew2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Character", crewsNextSetViewModel.Crew2.Character);
                crewsNextSetCssModel.Crew2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Port", crewsNextSetViewModel.Crew2.Port);
                crewsNextSetCssModel.Crew2.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2StocksLeftText", crewsNextSetViewModel.Crew2.StocksLeft ?? "?");

                crewsNextSetCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", crewsNextSetViewModel.Round);
                crewsNextSetCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", crewsNextSetViewModel.BestOf);

                _smashFileWriter.WriteCrewsNextSetFile(crewsNextSetViewModel.PathToFormatNextSet, crewsNextSetCssModel);
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
                var squadStrikeNextSetCssModel = new SquadStrikeNextSetCssModel();

                squadStrikeNextSetCssModel.Squad1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad1NameText", squadStrikeNextSetViewModel.Squad1.Name);
                squadStrikeNextSetCssModel.Squad1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad1Port", squadStrikeNextSetViewModel.Squad1.Port);

                for (var i = 0; i < squadStrikeNextSetViewModel.Squad1.Players.Count; i++)
                {
                    squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad1Player{i + 1}NameText", squadStrikeNextSetViewModel.Squad1.Players[i].Name) }\r\n";

                        squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad1Player{i + 1}TwitterText", squadStrikeNextSetViewModel.Squad1.Players[i].Twitter) }\r\n";
                    }

                    squadStrikeNextSetCssModel.Squad1.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"squad1Character{i + 1}", squadStrikeNextSetViewModel.Squad1.Players[i].Character) }\r\n";
                }

                squadStrikeNextSetCssModel.Squad2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "squad2NameText", squadStrikeNextSetViewModel.Squad2.Name);
                squadStrikeNextSetCssModel.Squad2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "squad2Port", squadStrikeNextSetViewModel.Squad2.Port);

                for (var i = 0; i < squadStrikeNextSetViewModel.Squad2.Players.Count; i++)
                {
                    squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels.Add(new SquadPlayerCssModel());

                    if (i < 4)
                    {
                        squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].NameAndSponsor = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad2Player{i + 1}NameText", squadStrikeNextSetViewModel.Squad2.Players[i].Name) }\r\n";

                        squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].Twitter = $"{ _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"squad2Player{i + 1}TwitterText", squadStrikeNextSetViewModel.Squad2.Players[i].Twitter) }\r\n";
                    }

                    squadStrikeNextSetCssModel.Squad2.SquadPlayerCssModels[i].CharacterPath = $"{ _textReplacer.ReplaceIdAndValue(_imageTemplateCss, $"squad2Character{i + 1}", squadStrikeNextSetViewModel.Squad2.Players[i].Character) }\r\n";
                }

                squadStrikeNextSetCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", squadStrikeNextSetViewModel.Round);
                squadStrikeNextSetCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", squadStrikeNextSetViewModel.BestOf);

                _smashFileWriter.WriteSquadStrikeNextSetFile(squadStrikeNextSetViewModel.PathToFormatNextSet, squadStrikeNextSetCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}