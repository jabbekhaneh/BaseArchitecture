using MediatR;
using Portal.Application.Localization.Languages.Add;
using Portal.Application.Localization.Languages.Commnads.Edit;
using Portal.Application.Localization.Languages.Commnads.Remove;
using Portal.Base.Common;
using Portal.Shared.Localization.Languages.DTOs;

namespace Portal.Application.Localization.Languages;

public static class LanguageServices
{
    public static async Task<BaseResult<long>> AddLanguage(this IMediator mediator, AddLanguageDto lan)
    {
        return await mediator.Send(new AddLanguageCommnad { Language = lan });
    }

    public static async Task<BaseResult<long>> EditLanguage(this IMediator mediator, long id, EditLanguageDto lan)
    {
        return await mediator.Send(new EditLanguageCommnad { Id = id, Language = lan });
    }

    public static async Task<BaseResult<long>> RemoveLanguage(this IMediator mediator, long id)
    {
        return await mediator.Send(new RemoveLanguageCommand { Id = id,});
    }
}
