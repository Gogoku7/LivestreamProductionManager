using System.Collections.Generic;

namespace LivestreamProductionManager.Interfaces
{
    public interface ITextReplacer
    {
        string ReplaceIdAndValue(string template, string id, string value);
        string ReplaceIdAndValueForPlayerName(string template, string id, string playerSponsor, string playerName);
        string ReplaceIdAndValueForPlayerNames(string template, string idTemplate, List<string> playerSponsors, List<string> playerNames);
        string ReplaceIdAndValueForTeam(string template, string idTemplate, List<string> values);
    }
}
