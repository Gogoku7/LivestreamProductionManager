using LivestreamProductionManager.Implementations.TraditionalFG;
using LivestreamProductionManager.Interfaces.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG;
using LivestreamProductionManager.ViewModels.FightingGames.TraditionalFG.NewSet;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class TraditionalFGController : BaseController
    {
        private readonly ITraditionalFGOverlayManager _traditionalFGCssOverlayManager = new TraditionalFGCssOverlayManager();
        private readonly ITraditionalFGOverlayManager _traditionalFGJsonOverlayManager = new TraditionalFGJsonOverlayManager();

        [HttpPost]
        public PartialViewResult GetManageCompetitors(PathsViewModel pathsViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(pathsViewModel) }");

                var traditionalFGViewModel = new TraditionalFGBaseViewModel
                {
                    Series = pathsViewModel.Series,
                    Game = pathsViewModel.Game,
                    Format = pathsViewModel.Format,
                    PathToSeries = pathsViewModel.PathToSeries,
                    PathToGame = pathsViewModel.PathToGame,
                    PathToFormat = pathsViewModel.PathToFormat
                };

                traditionalFGViewModel.Characters = _configReader.GetCharactersFromConfig(traditionalFGViewModel.PathToGame);
                traditionalFGViewModel.Countries = _configReader.GetCountriesFromConfig();

                return PartialView($"~/Views/TraditionalFG/{pathsViewModel.Format}/ManageCompetitors.cshtml", traditionalFGViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public PartialViewResult GetNextSet(PathsViewModel pathsViewModel, int index)
        {
            try
            {
                Log.Information($"Posted data to GetManageNextSet: { JsonConvert.SerializeObject(pathsViewModel) }");

                var traditionalFGQueuBaseViewModel = new TraditionalFGQueuBaseViewModel
                {
                    Index = index,
                    Series = pathsViewModel.Series,
                    Game = pathsViewModel.Game,
                    Format = pathsViewModel.Format,
                    PathToSeries = pathsViewModel.PathToSeries,
                    PathToGame = pathsViewModel.PathToGame,
                    PathToFormat = pathsViewModel.PathToFormat
                };

                traditionalFGQueuBaseViewModel.Characters = _configReader.GetCharactersFromConfig(traditionalFGQueuBaseViewModel.PathToGame);

                return PartialView($"~/Views/TraditionalFG/{pathsViewModel.Format}/NextSet.cshtml", traditionalFGQueuBaseViewModel);
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

                _traditionalFGCssOverlayManager.UpdateSinglesOverlay(singlesViewModel);
                _traditionalFGJsonOverlayManager.UpdateSinglesOverlay(singlesViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar("Something went wrong while saving competitor files, see the console for details.", ex);
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
                    throw new ArgumentNullException("One of the crews' players is null");
                }

                _traditionalFGCssOverlayManager.UpdateCrewsOverlay(crewsViewModel);
                _traditionalFGJsonOverlayManager.UpdateCrewsOverlay(crewsViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar("Something went wrong while saving competitor files, see the console for details.", ex);
            }
        }

        [HttpPost]
        public PartialViewResult GetCrewPlayers(int count, PathsViewModel pathsViewModel)
        {
            try
            {
                var crewPlayerPartialViewModel = new CrewPlayerPartialViewModel
                {
                    Count = count,
                    Characters = _configReader.GetCharactersFromConfig(pathsViewModel.PathToGame),
                };

                return PartialView($"~/Views/TraditionalFG/{pathsViewModel.Format}/CrewPlayerRow.cshtml", crewPlayerPartialViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public JsonResult UpdateSinglesNextSet(SinglesNextSetViewModel singlesNextSetViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(singlesNextSetViewModel) }");

                _traditionalFGCssOverlayManager.UpdateSinglesNextSetOverlay(singlesNextSetViewModel);
                _traditionalFGJsonOverlayManager.UpdateSinglesNextSetOverlay(singlesNextSetViewModel);

                return SuccessSnackbar("Successfully saved next set files.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public JsonResult UpdateCrewsNextSet(CrewsNextSetViewModel crewsNextSetViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(crewsNextSetViewModel) }");

                _traditionalFGCssOverlayManager.UpdateCrewsNextSetOverlay(crewsNextSetViewModel);
                _traditionalFGJsonOverlayManager.UpdateCrewsNextSetOverlay(crewsNextSetViewModel);

                return SuccessSnackbar("Successfully saved next set files.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}