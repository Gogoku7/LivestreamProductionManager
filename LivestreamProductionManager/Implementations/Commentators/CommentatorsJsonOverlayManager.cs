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
    public class CommentatorsJsonOverlayManager : ICommentatorsOverlayManager
    {
        private readonly ITemplateFileReader _templatefileReader = new TemplateFileReader("~/FightingGames/JsonTemplates/");
        private readonly ITextReplacer _textReplacer = new TextReplacer();
        private readonly ICommentatorsFileWriter _commentatorsFileWriter = new CommentatorsJsonFileWriter();

        private readonly string _textTemplateJson;

        public CommentatorsJsonOverlayManager()
        {
            _textTemplateJson = _templatefileReader.ReadTemplateFile("TextTemplateFile.json");
        }

        public void UpdateCommentatorsOverlay(string pathToCommentators, List<CommentatorViewModel> commentatorViewModels)
        {
            try
            {
                var commentatorsValuesModelList = new List<CommentatorsValuesModel>();

                for (var i = 0; i < commentatorViewModels.Count(); i++)
                {
                    commentatorsValuesModelList.Add
                    (
                        new CommentatorsValuesModel
                        {
                            Name = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"commentator{i + 1}NameText", commentatorViewModels[i].Name ?? ""),
                            Twitter = _textReplacer.ReplaceIdAndValue(_textTemplateJson, $"commentator{i + 1}TwitterText", commentatorViewModels[i].Twitter ?? "")
                        }
                    );
                }

                _commentatorsFileWriter.WriteCommentatorsFile(pathToCommentators, commentatorsValuesModelList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}