using LivestreamProductionManager.Implementations.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.SuperSmashBros;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class SuperSmashBrosController : BaseController
    {
        private readonly SmashOverlayManager _smashOverlayManager = new SmashOverlayManager();

        [HttpPost]
        public PartialViewResult GetManageCompetitors(string series, string game, string format, string pathToSeries, string pathToGame, string pathToFormat)
        {
            try
            {
                var superSmashBrosBaseViewModel = new SuperSmashBrosBaseViewModel(series, game, format, pathToSeries, pathToGame, pathToFormat)
                {
                    Characters = _configReader.GetCharactersFromConfig(pathToGame),
                    Ports = _configReader.GetPortsFromConfig(pathToGame)
                };

                return PartialView($"~/Views/{series}/{format}/ManageCompetitors.cshtml", superSmashBrosBaseViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public PartialViewResult GetCrewPlayers(int count, string series, string game, string format)
        {
            return PartialView($"~/Views/{series}/{format}/CrewPlayerRow.cshtml", count);
        }

        [HttpPost]
        public JsonResult UpdateSingles(SinglesViewModel singlesViewModel)
        {
            try
            {
                _smashOverlayManager.UpdateSinglesOverlay(singlesViewModel);

                return SuccessSnackbar("Successfully saved competitor files");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details");
            }
        }

        [HttpPost]
        public JsonResult UpdateDoubles(DoublesViewModel doublesViewModel)
        {
            try
            {
                _smashOverlayManager.UpdateDoublesOverlay(doublesViewModel);

                return SuccessSnackbar("Successfully saved competitor files");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details");
            }
        }

        [HttpPost]
        public JsonResult UpdateCrews(CrewsViewModel crewsViewModel)
        {
            try
            {
                if (crewsViewModel.Crew1.Players == null || crewsViewModel.Crew2.Players == null)
                {
                    throw new ArgumentNullException("One of the players is null");
                }

                //Save files

                return SuccessSnackbar("Successfully saved competitor files");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar(ex, "Something went wrong while saving competitor files, see the console for details");
            }
        }
    }
}