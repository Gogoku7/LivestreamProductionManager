using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.SuperSmashBros;
using Serilog;
using System;
using System.Linq;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new CssTemplateFileReader();
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly SmashFileWriter _fileWriter = new SmashFileWriter();

        private readonly string _textTemplateCss;
        private readonly string _imageTemplateCss;
        private readonly string _crewPlayerActiveTemplateCss;
        private readonly string _crewPlayerEliminatedTemplateCss;

        public SmashOverlayManager()
        {
            _textTemplateCss = _templatefileReader.ReadTemplateFile("TextTemplateFile.css");
            _imageTemplateCss = _templatefileReader.ReadTemplateFile("ImageTemplateFile.css");
            _crewPlayerActiveTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerActiveTemplateCss.css");
            _crewPlayerEliminatedTemplateCss = _templatefileReader.ReadTemplateFile("CrewPlayerEliminatedTemplateCss.css");
        }

        public void UpdateSinglesOverlay(SinglesViewModel singlesViewModel)
        {
            try
            {
                var singlesCssModel = new SinglesCssModel();
                singlesCssModel.Player1.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player1NameText", singlesViewModel.Player1.Sponsor, singlesViewModel.Player1.Name);
                singlesCssModel.Player1.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1TwitterText", singlesViewModel.Player1.Twitter ?? "");
                singlesCssModel.Player1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player1ScoreText", singlesViewModel.Player1.Score ?? "?");
                singlesCssModel.Player1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Character", singlesViewModel.Player1.Character ?? "../../CharacterIcons/random.png");
                singlesCssModel.Player1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player1Port", singlesViewModel.Player1.Port ?? "../../PlayerPorts/playerPortNo.png");

                singlesCssModel.Player2.NameAndSponsor = _textReplacer.ReplaceIdAndValueForPlayerName(_textTemplateCss, "player2NameText", singlesViewModel.Player2.Sponsor, singlesViewModel.Player2.Name);
                singlesCssModel.Player2.Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2TwitterText", singlesViewModel.Player2.Twitter ?? "");
                singlesCssModel.Player2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "player2ScoreText", singlesViewModel.Player2.Score ?? "?");
                singlesCssModel.Player2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Character", singlesViewModel.Player2.Character ?? "../../CharacterIcons/random.png");
                singlesCssModel.Player2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "player2Port", singlesViewModel.Player2.Port ?? "../../PlayerPorts/playerPortNo.png");

                singlesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", singlesViewModel.Tournament ?? "");
                singlesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", singlesViewModel.Extra ?? "");
                singlesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", singlesViewModel.Round ?? "");
                singlesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", singlesViewModel.BestOf + "");

                _fileWriter.WriteSinglesCssFile(singlesViewModel.PathToFormat, singlesCssModel);
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

                doublesCssModel.Team1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team1NameText", doublesViewModel.Team1.Name ?? "");
                doublesCssModel.Team1.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team1ScoreText", doublesViewModel.Team1.Score ?? "?");
                doublesCssModel.Team1.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team1Player*NameText", doublesViewModel.Team1.Players.Select(p => p.Sponsor).ToList(), doublesViewModel.Team1.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team1.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Character", doublesViewModel.Team1.Players.Select(p => p.Character ?? "../../CharacterIcons/random.png").ToList());
                doublesCssModel.Team1.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team1Player*Port", doublesViewModel.Team1.Players.Select(p => p.Port ?? "../../PlayerPorts/playerPortNo.png").ToList());

                doublesCssModel.Team2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team2NameText", doublesViewModel.Team2.Name ?? "");
                doublesCssModel.Team2.Score = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "team2ScoreText", doublesViewModel.Team2.Score ?? "?");
                doublesCssModel.Team2.PlayerNamesAndSponsors = _textReplacer.ReplaceIdAndValueForPlayerNames(_textTemplateCss, "team2Player*NameText", doublesViewModel.Team2.Players.Select(p => p.Sponsor).ToList(), doublesViewModel.Team2.Players.Select(p => p.Name).ToList());
                doublesCssModel.Team2.CharacterPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Character", doublesViewModel.Team2.Players.Select(p => p.Character ?? "../../CharacterIcons/random.png").ToList());
                doublesCssModel.Team2.PortPaths = _textReplacer.ReplaceIdAndValueForTeam(_imageTemplateCss, "team2Player*Port", doublesViewModel.Team2.Players.Select(p => p.Port ?? "../../PlayerPorts/playerPortNo.png").ToList());

                doublesCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", doublesViewModel.Tournament ?? "");
                doublesCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", doublesViewModel.Extra ?? "");
                doublesCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", doublesViewModel.Round ?? "");
                doublesCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", doublesViewModel.BestOf ?? "");

                _fileWriter.WriteDoublesCssFile(doublesViewModel.PathToFormat, doublesCssModel);
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

                crewsCssModel.Crew1.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1NameText", crewsViewModel.Crew1.Name ?? "");
                crewsCssModel.Crew1.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Character", crewsViewModel.Crew1.Character ?? "../../CharacterIcons/random.png");
                crewsCssModel.Crew1.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew1Port", crewsViewModel.Crew1.Port ?? "../../PlayerPorts/playerPortNo.png");
                crewsCssModel.Crew1.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew1StocksLeftText", crewsViewModel.Crew1.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew1.Players.Count; i++)
                {
                    if (crewsViewModel.Crew1.Players[i].Active)
                    {
                        crewsCssModel.Crew1.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_crewPlayerActiveTemplateCss, $"crew1Player{i+1}NameText", crewsViewModel.Crew1.Players[i].Name) + "\r\n";
                    }
                    else if (crewsViewModel.Crew1.Players[i].Eliminated)
                    {
                        crewsCssModel.Crew1.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_crewPlayerEliminatedTemplateCss, $"crew1Player{i+1}NameText", crewsViewModel.Crew1.Players[i].Name) + "\r\n";
                    }
                    else
                    {
                        crewsCssModel.Crew1.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew1Player{i+1}NameText", crewsViewModel.Crew1.Players[i].Name) + "\r\n";
                    }
                }

                crewsCssModel.Crew2.Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2NameText", crewsViewModel.Crew2.Name ?? "");
                crewsCssModel.Crew2.CharacterPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Character", crewsViewModel.Crew2.Character ?? "../../CharacterIcons/random.png");
                crewsCssModel.Crew2.PortPath = _textReplacer.ReplaceIdAndValue(_imageTemplateCss, "crew2Port", crewsViewModel.Crew2.Port ?? "../../PlayerPorts/playerPortNo.png");
                crewsCssModel.Crew2.StocksLeft = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "crew2StocksLeftText", crewsViewModel.Crew2.StocksLeft ?? "?");

                for (var i = 0; i < crewsViewModel.Crew2.Players.Count; i++)
                {
                    if (crewsViewModel.Crew2.Players[i].Active)
                    {
                        crewsCssModel.Crew2.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_crewPlayerActiveTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) + "\r\n";
                    }
                    else if (crewsViewModel.Crew2.Players[i].Eliminated)
                    {
                        crewsCssModel.Crew2.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_crewPlayerEliminatedTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) + "\r\n";
                    }
                    else
                    {
                        crewsCssModel.Crew2.PlayerNamesAndSponsors += _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"crew2Player{i + 1}NameText", crewsViewModel.Crew2.Players[i].Name) + "\r\n";
                    }
                }

                crewsCssModel.Tournament = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "tournamentText", crewsViewModel.Tournament ?? "");
                crewsCssModel.Extra = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "extraText", crewsViewModel.Extra ?? "");
                crewsCssModel.Round = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "roundText", crewsViewModel.Round ?? "");
                crewsCssModel.BestOf = _textReplacer.ReplaceIdAndValue(_textTemplateCss, "bestOfText", crewsViewModel.BestOf ?? "");

                _fileWriter.WriteCrewsCssFile(crewsViewModel.PathToFormat, crewsCssModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}