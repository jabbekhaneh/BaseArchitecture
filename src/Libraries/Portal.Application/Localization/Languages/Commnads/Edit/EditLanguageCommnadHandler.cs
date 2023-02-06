using Portal.Base.Common;
using Portal.Shared.Localization.Languages;

namespace Portal.Application.Localization.Languages.Commnads.Edit;


public class EditLanguageCommnadHandler : BaseCommandHandler<EditLanguageCommnad, long>
{
    private readonly BaseLanguageRepository _languageRepository;

    public EditLanguageCommnadHandler(BaseLanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<BaseResult<long>> Handle(EditLanguageCommnad request, CancellationToken cancellationToken)
    {
        var language = await _languageRepository.Cammand.FindById(request.Id);

        language.Edit(request.Language.Name, 
                      request.Language.Title,
                      request.Language.IsRtl);
        
        return BaseResult<long>.BuildSuccess(language.Id);
    }
}
