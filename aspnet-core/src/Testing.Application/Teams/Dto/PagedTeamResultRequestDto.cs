using Abp.Application.Services.Dto;

namespace Testing.Teams.Dto
{
    public class PagedTeamResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
