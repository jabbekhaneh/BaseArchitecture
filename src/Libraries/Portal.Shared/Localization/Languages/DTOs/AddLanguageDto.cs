using System.ComponentModel.DataAnnotations;

namespace Portal.Shared.Localization.Languages.DTOs;

public class AddLanguageDto
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
    public bool IsRtl { get; set; } = false;
}
