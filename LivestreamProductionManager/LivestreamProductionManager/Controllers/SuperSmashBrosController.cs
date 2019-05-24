﻿using LivestreamProductionManager.Implementations.SuperSmashBros;
using LivestreamProductionManager.Interfaces.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class SuperSmashBrosController : BaseController
    {
        private readonly ISmashOverlayManager _smashCssOverlayManager = new SmashCssOverlayManager();
        private readonly ISmashOverlayManager _smashJsonOverlayManager = new SmashJsonOverlayManager();

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

                _smashCssOverlayManager.UpdateSinglesOverlay(singlesViewModel);
                _smashJsonOverlayManager.UpdateSinglesOverlay(singlesViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                return ErrorSnackbar("Something went wrong while saving competitor files, see the console for details.", ex);
            }
        }

        [HttpPost]
        public JsonResult UpdateDoubles(DoublesViewModel doublesViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(doublesViewModel) }");

                _smashCssOverlayManager.UpdateDoublesOverlay(doublesViewModel);
                _smashJsonOverlayManager.UpdateDoublesOverlay(doublesViewModel);

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

                _smashCssOverlayManager.UpdateCrewsOverlay(crewsViewModel);
                _smashJsonOverlayManager.UpdateCrewsOverlay(crewsViewModel);

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

                return PartialView($"~/Views/{pathsViewModel.Series}/{pathsViewModel.Format}/CrewPlayerRow.cshtml", crewPlayerPartialViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public JsonResult UpdateSquadStrike(SquadStrikeViewModel squadStrikeViewModel)
        {
            try
            {
                Log.Information($"Submitted data: { JsonConvert.SerializeObject(squadStrikeViewModel) }");

                if (squadStrikeViewModel.Squad1.Players == null || squadStrikeViewModel.Squad2.Players == null)
                {
                    throw new ArgumentNullException("One of the squad's players is null");
                }

                _smashCssOverlayManager.UpdateSquadStrikeOverlay(squadStrikeViewModel);
                _smashJsonOverlayManager.UpdateSquadStrikeOverlay(squadStrikeViewModel);

                return SuccessSnackbar("Successfully saved competitor files.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw;
            }
        }
    }
}