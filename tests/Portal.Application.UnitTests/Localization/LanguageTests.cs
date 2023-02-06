using Portal.Application.UnitTests.Localization.Extentions;
using Portal.Application.UnitTests.Localization.Repositories;
using Portal.Application.UnitTests.Localization.TestBuildes;
using Portal.Infrastructure.Languages;
using Portal.Infrastructure.Localization.Languages;
using Portal.Shared.Localization.Languages;
using Portal.Shared.Localization.Languages.Exceptions;


namespace Portal.Application.UnitTests.Localization;

public class LanguageTests : BaseApplicationTestConfiguration
{
    private readonly BaseLanguageRepository _repository;
    private readonly CammandLanguageRepository _commandRepository;
    private readonly QueryLanguageRepository _queryLanguageRepository;

    public LanguageTests()
    {
        _queryLanguageRepository = new QueryLanguageRepositoryInMemory();
        _commandRepository = new EFLanguageRepository(DatabaseInMemory);
        _repository = new LanguageRepository(_commandRepository, _queryLanguageRepository);
    }

    [Fact]
    public async Task Add_Language_Should_Return_Language()
    {
        //arrange
        var addLanguageDto = new AddLanguageDtoTestBuilder().Build();


        //act

        var actual = await _repository.AddLanguageHandler(addLanguageDto);


        //assert

        actual.IsSuccess.Should().BeTrue();
        var language = DatabaseInMemory.Languages.Find(actual.Result);
        language.Title.Should().Be(addLanguageDto.Title);
        language.Name.Should().Be(addLanguageDto.Name);
    }

    [Fact]
    public async Task Add_Language_Should_Exception_DublicateLanguage()
    {
        //arrange
        var language = new LanguageTestBuilder().Build();
        DatabaseInMemory.AddLanguage(language);
        var addLanguageDto = new AddLanguageDtoTestBuilder().WithName(language.Name).Build();

        //act
        Func<Task> executed = () => _repository.AddLanguageHandler(addLanguageDto);

        //assert
        await executed.Should().ThrowExactlyAsync<DublicateLanguageException>();

    }

    [Fact]
    public async Task Edit_Language_Should_Return_EditLanguage()
    {
        //arrange
        var language = new LanguageTestBuilder().Build();
        DatabaseInMemory.AddLanguage(language);
        var editLanguage = new EditLanguageDtoTestBuilder().Build();

        //act
        await _repository.EditLanguageHandler(language.Id,editLanguage);
        
        //assert

        var expected = DatabaseInMemory.Languages.Find(language.Id);
        expected.Title.Should().Be(editLanguage.Title);
        expected.Name.Should().Be(editLanguage.Name);
        expected.IsRtl.Should().Be(editLanguage.IsRtl);
    }

}