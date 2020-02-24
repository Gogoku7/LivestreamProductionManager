namespace LivestreamProductionManager.Models.FightingGames
{
    public class SelectorValueModel
    {
        public string Selector { get; set; }
        public string Value { get; set; }

        public SelectorValueModel(string selector, string value)
        {
            Selector = selector;
            Value = value;
        }
    }
}