using LivestreamProductionManager.Models.Commentators;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsFileWriter
    {
        void WriteCommentatorsFile(string pathToCommentators, List<CommentatorsValuesModel> commentatorsValuesModels);
    }
}
