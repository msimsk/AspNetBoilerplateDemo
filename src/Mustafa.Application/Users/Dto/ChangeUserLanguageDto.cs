using System.ComponentModel.DataAnnotations;

namespace Mustafa.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}