using Microsoft.EntityFrameworkCore;
using Portal.Domain.Localization;
using Portal.Shared.Localization.Languages;
using System.Collections.Generic;

namespace Portal.Application.UnitTests.Localization.Repositories;

public class QueryLanguageRepositoryInMemory : BaseApplicationTestConfiguration, QueryLanguageRepository  
{
    

    public async Task<ICollection<Language>> GetAll()
    {
        return await DatabaseInMemory.Languages.ToListAsync();
    }

    public async Task<Language> GetById(long id)
    {
        return await DatabaseInMemory.Languages.SingleOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<int> GetCount()
    {
        return await DatabaseInMemory.Languages.CountAsync();
    }

    public async Task<bool> IsExistByName(string name)
    {
        return await DatabaseInMemory.Languages.AnyAsync(_ => _.Name == name);
    }
}
