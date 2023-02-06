using Portal.Application.UnitTests.Configs.Builders;
using Portal.Shared.Localization.Languages.DTOs;

namespace Portal.Application.UnitTests.Localization.TestBuildes;

public class AddLanguageDtoTestBuilder : ReflectionBuilder<AddLanguageDto>
{
    private string _name = $"Dummy-Name{random.Next()}".ToLower();
    private string _title = $"Dummy-Title{random.Next()}".ToLower();

    public AddLanguageDtoTestBuilder()
    {
        
    }



    public AddLanguageDtoTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    
    public override AddLanguageDto Build()
    {
        return Builder = Builder<AddLanguageDto>.CreateNew()
           .With(_ => _.Name, _name)
           .With(_ => _.Title, _title)
           .With(_ => _.IsRtl, true)
           .Build();   
    }

}
