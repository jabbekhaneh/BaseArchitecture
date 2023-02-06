using System.ComponentModel.DataAnnotations;

namespace Portal.Shared.Localization.Languages.DTOs;

public class EditLanguageDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    public bool IsRtl { get; set; }
    
}
