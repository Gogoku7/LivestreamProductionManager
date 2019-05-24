namespace LivestreamProductionManager.Interfaces
{
    interface IFileReader
    {
        string ReadCssFile(string pathToFormat);
        string ReadJsonFile(string pathToFormat);
    }
}
