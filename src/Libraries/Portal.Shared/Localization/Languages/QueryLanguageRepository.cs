using Portal.Base.CQRS.Query;
using Portal.Domain.Localization;

namespace Portal.Shared.Localization.Languages;

public interface QueryLanguageRepository : BaseQueryRepository<Language>
{
    Task<bool> IsExistByName(string name);
}
