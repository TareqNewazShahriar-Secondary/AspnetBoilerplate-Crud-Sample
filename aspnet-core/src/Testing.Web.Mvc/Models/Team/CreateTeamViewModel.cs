using System.ComponentModel.DataAnnotations;

namespace Testing.Web.Models.Team
{
    public class CreateTeamViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
