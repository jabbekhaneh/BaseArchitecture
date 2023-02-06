using Portal.Base.Common;
using Portal.Base.CQRS.Command;
using Portal.Domain.Localization;
using Portal.Shared.Common;
using Portal.Shared.Localization.Languages;
using Portal.Shared.Localization.Languages.Exceptions;

namespace Portal.Application.Localization.Languages.Add;

public class AddLanguageCommnadHandler : BaseCommandHandler<AddLanguageCommnad, long>
{
    private readonly BaseLanguageRepository _repository;

    public AddLanguageCommnadHandler(BaseLanguageRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult<long>> Handle(AddLanguageCommnad request, CancellationToken cancellationToken)
    {
        if (await _repository.Query.IsExistByName(request.Language.Name))
            throw new DublicateLanguageException();

        var newLan = new Language(request.Language.Name, request.Language.Title, request.Language.IsRtl);
        await _repository.Cammand.Insert(newLan);
        return BaseResult<long>.BuildSuccess(newLan.Id);
    }
}
