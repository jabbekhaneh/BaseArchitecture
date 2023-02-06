using Portal.Shared.Localization.Languages;

namespace Portal.Infrastructure.Localization.Languages;

public class LanguageRepository : BaseLanguageRepository
{
    public CammandLanguageRepository Cammand { get; }
    public QueryLanguageRepository Query { get; }

    public LanguageRepository(CammandLanguageRepository cammand, QueryLanguageRepository query)
    {
        Cammand = cammand;
        Query = query;
    }
}
