using Portal.Domain.Localization;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Persistence.Repositories;
using Portal.Shared.Localization.Languages;

namespace Portal.Infrastructure.Languages;

public class EFLanguageRepository : EFRepository<Language>, CammandLanguageRepository
{
    public EFLanguageRepository(DatabaseContext context) : base(context)
    {

    }

}
