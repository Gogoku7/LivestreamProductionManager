namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class SnackbarViewModel
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public SnackbarViewModel(bool success, string message, string errorMessage = null)
        {
            Success = success.ToString();
            Message = message;
            if (!success)
            {
                ErrorMessage = errorMessage;
            }
            
        }
    }
}