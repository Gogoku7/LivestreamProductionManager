using LivestreamProductionManager.Models.Commentators;
using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsFileWriter
    {
        void WriteCommentatorsFile(string pathToGame, List<CommentatorsValuesModel> commentatorsValuesModels);
    }
}
