using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Testing.Teams.Dto
{
    public class TeamDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
