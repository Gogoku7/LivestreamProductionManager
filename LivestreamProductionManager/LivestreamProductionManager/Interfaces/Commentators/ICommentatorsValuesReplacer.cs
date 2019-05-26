using LivestreamProductionManager.Models.Commentators;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsValuesReplacer
    {
        string ReplaceValuesForCommentators(string fileTemplate, List<CommentatorsValuesModel> commentatorsValuesModels);
    }
}