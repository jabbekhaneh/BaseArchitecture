using Dapper;
using Microsoft.Extensions.Options;
using Portal.Base.Dapper;
using Portal.Base.Options;
using Portal.Domain.Localization;
using Portal.Shared.Localization.Languages;

namespace Portal.Infrastructure.Localization.Languages;

public class DapperLanguageRepository : BaseDapperSqlServerData<Language>, QueryLanguageRepository
{
    public DapperLanguageRepository(IOptions<BaseOptions> options) : base(options)
    {
    }

    public async Task<bool> IsExistByName(string name)
    {
        string query = "select count(1) from Languages where Name=@name";
        return await Connection.ExecuteScalarAsync<bool>(query, new { name });
    }
}
