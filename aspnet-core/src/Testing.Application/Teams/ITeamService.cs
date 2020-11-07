using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.Teams.Dto;

namespace Testing.Teams
{
    public interface ITeamService
        : IAsyncCrudAppService<TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, TeamDto>
    {
    }
}
