using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.Teams.Dto;

namespace Testing.Teams
{
    public interface ITeamService
    {
        Task<TeamDto> CreateAsync(CreateTeamDto input);
    }
}
