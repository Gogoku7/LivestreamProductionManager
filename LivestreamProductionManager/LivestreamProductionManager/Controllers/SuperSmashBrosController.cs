using LivestreamProductionManager.Implementations.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.SuperSmashBros;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class SuperSmashBrosController : BaseController
    {
        private readonly SmashOverlayManager _smashOverlayManager = new SmashOverlayManager();

        [HttpPost]
        public PartialViewResult GetManageCompetitors(PathsViewModel pathsViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(pathsViewModel) }");

                var superSmashBrosBaseViewModel = new SuperSmashBrosBaseViewModel
                {
                    Series = pathsViewModel.Series,
                    Game = pathsViewModel.Game,
                    Format = pathsViewModel.Format,
                    PathToSeries = pathsViewModel.PathToSeries,
                    PathToGame = pathsViewModel.PathToGame,
                    PathToFormat = pathsViewModel.PathToFormat
                };

                superSmashBrosBaseViewModel.Characters = _configReader.GetCharactersFromConfig(superSmashBrosBaseViewModel.PathToGame);
                superSmashBrosBaseViewModel.Ports = _configReader.GetPortsFromConfig(superSmashBrosBaseViewModel.PathToGame);

                return PartialView($"~/Views/{pathsViewModel.Series}/{pathsViewModel.Format}/ManageCompetitors.cshtml", superSmashBrosBaseViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public JsonResult UpdateSingles(SinglesViewModel singlesViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(singlesViewModel) }");

                _smashOverlayManager.UpdateSinglesOverlay(singlesViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details.");
            }
        }

        [HttpPost]
        public JsonResult UpdateDoubles(DoublesViewModel doublesViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(doublesViewModel) }");

                _smashOverlayManager.UpdateDoublesOverlay(doublesViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details.");
            }
        }

        [HttpPost]
        public JsonResult UpdateCrews(CrewsViewModel crewsViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(crewsViewModel) }");

                if (crewsViewModel.Crew1.Players == null || crewsViewModel.Crew2.Players == null)
                {
                    throw new ArgumentNullException("One of the players is null");
                }

                _smashOverlayManager.UpdateCrewsOverlay(crewsViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details.");
            }
        }

        [HttpPost]
        public PartialViewResult GetCrewPlayers(int count, PathsViewModel pathsViewModel)
        {
            try
            {
                return PartialView($"~/Views/{pathsViewModel.Series}/{pathsViewModel.Format}/CrewPlayerRow.cshtml", count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}