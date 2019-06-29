using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.Models.Commentators;
using LivestreamProductionManager.ViewModels.Commentators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsCssOverlayManager : ICommentatorsOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ICommentatorsFileWriter _commentatorsFileWriter = new CommentatorsCssFileWriter();

        private readonly string _textTemplateCss;
        private readonly string _imageTemplateCss;

        public CommentatorsCssOverlayManager()
        {
            _textTemplateCss = _templatefileReader.ReadTemplateFile("TextTemplateFile.css");
            _imageTemplateCss = _templatefileReader.ReadTemplateFile("ImageTemplateFile.css");
        }

        public void UpdateCommentatorsOverlay(string pathToGame, List<CommentatorViewModel> commentatorViewModels)
        {
            try
            {
                var commentatorsValuesModelList = new List<CommentatorsValuesModel>();

                for (var i = 0; i < commentatorViewModels.Count(); i++)
                {
                    commentatorsValuesModelList.Add(
                        new CommentatorsValuesModel
                        {
                            Name = _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"commentator{i + 1}NameText", commentatorViewModels[i].Name ?? ""),
                            Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateCss, $"commentator{i + 1}TwitterText", commentatorViewModels[i].Twitter ?? "")
                        }
                    );
                }

                _commentatorsFileWriter.WriteCommentatorsFile(pathToGame, commentatorsValuesModelList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}