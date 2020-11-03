using System.ComponentModel.DataAnnotations;

namespace Testing.Web.Models.Teams
{
    public class CreateTeamViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
