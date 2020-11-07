using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Controllers;
using Testing.Teams;
using Testing.Teams.Dto;
using Testing.Web.Models.Teams;

namespace Testing.Web.Controllers
{
    public class TeamsController : TestingControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int teamId)
        {
            var team = await _teamService.GetAsync(new EntityDto<int>(teamId));
            var model = new EditTeamModalViewModel
            {
                Team = team
            };
            return PartialView("_EditModal", model);
        }
    }
}
