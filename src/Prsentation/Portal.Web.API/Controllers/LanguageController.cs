using Portal.Application.Localization.Languages;
using Portal.Shared.Localization.Languages.DTOs;
namespace Portal.Web.API.Controllers;
public class LanguageController : BaseController
{
    public LanguageController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost]
    public async Task<IActionResult> Add(AddLanguageDto lan)
    {
        return Ok(await Mediator.AddLanguage(lan));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(long id, EditLanguageDto lan)
    {
        return Ok(await Mediator.EditLanguage(id,lan));
    }
}
