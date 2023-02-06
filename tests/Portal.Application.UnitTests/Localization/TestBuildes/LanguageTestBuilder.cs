using Portal.Application.UnitTests.Configs.Builders;
using Portal.Domain.Localization;

namespace Portal.Application.UnitTests.Localization.TestBuildes;

public class LanguageTestBuilder : ReflectionBuilder<Language>
{
    private string _name = $"Dummy-name{random.Next()}";
    private string _title = $"Dummy-title{random.Next()}";

    public LanguageTestBuilder()
    {

    }

    public LanguageTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    public override Language Build()
    {
        return Builder = new Language(_name, _title);
    }
}
