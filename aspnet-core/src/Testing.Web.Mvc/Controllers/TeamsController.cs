using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult> PrintList(int print = 1)
        {
            var teams = await _teamService.GetAllAsync(new Teams.Dto.PagedTeamResultRequestDto { MaxResultCount = int.MaxValue });
            return PartialView("_PrintList", teams.Items.ToList());
        }

        public async Task<IActionResult> GenerateExcel()
        {
            var input = new PagedTeamResultRequestDto { SkipCount = 0, MaxResultCount = int.MaxValue };
            var genExcel = new GenerateExcel<TeamDto>((await _teamService.GetAllAsync(input)).Items);
            var stream = genExcel.Gererate();

            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "TeamList.xlsx";
            
            return File(stream, contentType, fileName);
        }
    }
}
