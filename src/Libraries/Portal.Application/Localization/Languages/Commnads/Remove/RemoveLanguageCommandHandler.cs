using Portal.Base.Common;
using Portal.Shared.Localization.Languages;
using Portal.Shared.Localization.Languages.Exceptions;

namespace Portal.Application.Localization.Languages.Commnads.Remove;

public class RemoveLanguageCommandHandler : BaseCommandHandler<RemoveLanguageCommand, long>
{
    private readonly BaseLanguageRepository _languageRepository;
    public RemoveLanguageCommandHandler(BaseLanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<BaseResult<long>> Handle(RemoveLanguageCommand request, CancellationToken cancellationToken)
    {
        var language= await _languageRepository.Cammand.FindById(request.Id);

        if (language == null)
            throw new NotFoundLanguageException();

         _languageRepository.Cammand.Delete(language);

        return BaseResult<long>.BuildSuccess(language.Id);
    }
}
