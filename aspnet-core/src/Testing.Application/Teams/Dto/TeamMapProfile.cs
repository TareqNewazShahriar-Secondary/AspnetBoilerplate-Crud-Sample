using AutoMapper;

namespace Testing.Teams.Dto
{
    public class TeamMapProfile : Profile
    {
        public TeamMapProfile()
        {
            CreateMap<TeamDto, Team>().ReverseMap();
            CreateMap<TeamDto, Team>()
                .ForMember(x => x.TenantId, opt => opt.Ignore());

            CreateMap<CreateTeamDto, Team>();
            CreateMap<CreateTeamDto, Team>()
                .ForMember(x => x.TenantId, opt => opt.Ignore());
        }
    }
}
