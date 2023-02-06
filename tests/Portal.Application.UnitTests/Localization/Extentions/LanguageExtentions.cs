using Portal.Application.Localization.Languages.Add;
using Portal.Application.Localization.Languages.Commnads.Edit;
using Portal.Application.Localization.Languages.Commnads.Remove;
using Portal.Base.Common;
using Portal.Domain.Localization;
using Portal.Infrastructure.Persistence;
using Portal.Shared.Localization.Languages;
using Portal.Shared.Localization.Languages.DTOs;
using System.Threading;

namespace Portal.Application.UnitTests.Localization.Extentions;

public static class LanguageExtentions
{
    public static async Task<BaseResult<long>> AddLanguageHandler(this BaseLanguageRepository repository, AddLanguageDto addLanguageDto)
    {
        var request = new AddLanguageCommnad
        {
            Language = addLanguageDto,
        };
        var handler = new AddLanguageCommnadHandler(repository);
        return await handler.Handle(request, CancellationToken.None);
    }

    public static void AddLanguage(this DatabaseContext context, Language language)
    {
        context.Languages.Add(language);
        context.SaveChanges();

    }

    public static async Task<BaseResult<long>> EditLanguageHandler(this BaseLanguageRepository repository, long languageId, EditLanguageDto language)
    {
        var request = new EditLanguageCommnad
        {
            Id = languageId,
            Language = language,
        };

        var handler = new EditLanguageCommnadHandler(repository);
        return await handler.Handle(request, CancellationToken.None);
        
    }

    public static async Task<BaseResult<long>> RemoveLanguageHandler(this BaseLanguageRepository repository, long languageId)
    {
        var request = new RemoveLanguageCommand
        {
            Id = languageId,
        };
        var handler = new RemoveLanguageCommandHandler(repository);
        return await handler.Handle(request, CancellationToken.None);

    }
}

