using System.ComponentModel.DataAnnotations;

namespace OSW.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}