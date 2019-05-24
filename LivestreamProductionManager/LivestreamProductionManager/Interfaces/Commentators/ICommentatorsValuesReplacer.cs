using LivestreamProductionManager.Models.Commentators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivestreamProductionManager.Interfaces.Commentators
{
    public interface ICommentatorsValuesReplacer
    {
        string ReplaceValuesForCommentators(string fileTemplate, CommentatorsValuesModel commentatorsValuesModel);
    }
}
