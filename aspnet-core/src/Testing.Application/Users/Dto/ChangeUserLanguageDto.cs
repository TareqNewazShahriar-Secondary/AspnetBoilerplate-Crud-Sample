using System.ComponentModel.DataAnnotations;

namespace Testing.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}