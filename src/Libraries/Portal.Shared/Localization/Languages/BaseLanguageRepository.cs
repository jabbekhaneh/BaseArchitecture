
namespace Portal.Shared.Localization.Languages;

public interface BaseLanguageRepository
{
    CammandLanguageRepository Cammand { get; }
    QueryLanguageRepository Query { get; }
}
