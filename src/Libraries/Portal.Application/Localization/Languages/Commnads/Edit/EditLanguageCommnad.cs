using Portal.Shared.Localization.Languages.DTOs;

namespace Portal.Application.Localization.Languages.Commnads.Edit;

public class EditLanguageCommnad : BaseCommand<long>
{
    public long Id { get; set; }
    public EditLanguageDto Language { get; set; }
}
