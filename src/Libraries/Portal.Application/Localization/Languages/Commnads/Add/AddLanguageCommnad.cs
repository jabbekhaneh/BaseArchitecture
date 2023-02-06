using Portal.Shared.Localization.Languages.DTOs;

namespace Portal.Application.Localization.Languages.Add;
public class AddLanguageCommnad : BaseCommand<long>
{
    public AddLanguageDto Language { get; set; } 
}
