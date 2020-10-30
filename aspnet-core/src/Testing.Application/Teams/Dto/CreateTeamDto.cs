using Abp.Extensions;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;

namespace Testing.Teams.Dto
{
    public class CreateTeamDto : IShouldNormalize
    {
        [Required]
        public string Name { get; set; }

        public void Normalize()
        {
            if (!Name.IsNullOrEmpty())
                Name = Name.Trim();
        }
    }
}
