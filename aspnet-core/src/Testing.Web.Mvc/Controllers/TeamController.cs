using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Controllers;
using Testing.Teams;
using Testing.Teams.Dto;
using Testing.Web.Models.Team;

namespace Testing.Web.Controllers
{
    public class TeamController : TestingControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Creating(CreateTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createTeamDto = new CreateTeamDto { Name = model.Name };
                await _teamService.CreateAsync(createTeamDto);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
