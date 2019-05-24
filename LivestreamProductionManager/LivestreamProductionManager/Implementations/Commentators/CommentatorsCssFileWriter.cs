using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.Interfaces.Commentators;
using LivestreamProductionManager.Models.Commentators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LivestreamProductionManager.Implementations.Commentators
{
    public class CommentatorsCssFileWriter : ICommentatorsFileWriter
    {
        private readonly ITemplateFileReader _templateFileReader = new TemplateFileReader("~/FightingGames/CssTemplates/");
        private readonly ICommentatorsValuesReplacer _smashTextReplacer = new SmashCssReplacer();

        public void WriteCommentatorsFile(string pathToFormat, CommentatorsValuesModel commentatorsValuesModel)
        {
            throw new NotImplementedException();
        }
    }
}