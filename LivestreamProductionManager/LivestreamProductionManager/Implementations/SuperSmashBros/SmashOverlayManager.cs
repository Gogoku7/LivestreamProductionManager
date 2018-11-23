using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Models.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.SuperSmashBros;
using System;
using System.Linq;

namespace LivestreamProductionManager.Implementations.SuperSmashBros
{
    public class SmashOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new CssTemplateFileReader();
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly SmashCssFileWriter _fileWriter = new SmashCssFileWriter();

        private readonly string _textTemplateCss;
        private readonly string _imageTemplateCss;

        public SmashOverlayManager()
        {
            _textTemplateCss = _templatefileReader.ReadTemplateFile("TextTemplateFile.css");
            _imageTemplateCss = _templatefileReader.ReadTemplateFile("ImageTemplateFile.css");
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
                Console.WriteLine(ex);
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
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateCrewsOverlay(CrewsViewModel crewsViewModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}