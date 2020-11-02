using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.Authorization;
using Testing.Teams.Dto;

namespace Testing.Teams
{
    [AbpAuthorize(PermissionNames.Pages_Users)] // TODO: PermissionNames.Pages_Users used, because not sure what is it and how it needs to be created
    public class TeamService :
        AsyncCrudAppService<Team, TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, TeamDto>,
        ITeamService
    {
        private readonly IRepository<Team, int> _teamRepository;
        private readonly IAbpSession _abpSession;

        public TeamService(IRepository<Team, int> repository,
            IAbpSession abpSession) 
            : base(repository)
        {
            _abpSession = abpSession;
            _teamRepository = repository;
        }

        public override async Task<TeamDto> CreateAsync(CreateTeamDto input)
        {
            CheckCreatePermission();

            var team = ObjectMapper.Map<Team>(input);
            
            team.TenantId = AbpSession.TenantId;

            var teamInserted = await _teamRepository.InsertAsync(team);

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(team);
        }
    }
}
