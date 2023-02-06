using Portal.Application.UnitTests.Configs.Builders;
using Portal.Shared.Localization.Languages.DTOs;

namespace Portal.Application.UnitTests.Localization.TestBuildes;

public class EditLanguageDtoTestBuilder : ReflectionBuilder<EditLanguageDto>
{
    private string _name = $"Dummy-Edit-Name{random.Next()}".ToLower();
    private string _title = $"Dummy-Edit-Title{random.Next()}".ToLower();
    public EditLanguageDtoTestBuilder()
    {

    }
    public override EditLanguageDto Build()
    {
        return Builder = Builder<EditLanguageDto>.CreateNew()
           .With(_ => _.Name, _name)
           .With(_ => _.Title, _title)
           .With(_ => _.IsRtl, true)
           .Build();
    }
}
