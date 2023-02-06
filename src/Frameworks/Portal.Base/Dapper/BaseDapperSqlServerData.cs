using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using Portal.Base.CQRS.Query;
using Portal.Base.Options;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Portal.Base.Dapper;

public class BaseDapperSqlServerData<TEntity> :  BaseQueryRepository<TEntity>
{
    protected IOptions<BaseOptions> Options;
    protected IDbConnection Connection;
    public BaseDapperSqlServerData(IOptions<BaseOptions> options)
    {
        Options = options;
        if (options.Value.UseInMemoryDatabase)
            SetOptionInMemory(options);
        else
            SetOption(options);

    }

    private void SetOption(IOptions<BaseOptions> options)
    {
        if (string.IsNullOrEmpty(options.Value.ConnectionString))
            throw new ArgumentNullException($"{nameof(options.Value.ConnectionString)}");
        Connection = new SqlConnection(options.Value.ConnectionString);
    }
    private void SetOptionInMemory(IOptions<BaseOptions> options)
    {
        var connectionInMemory = new SqliteConnection(options.Value.InMemoryDatabaseConnection);
        Connection = connectionInMemory;
    }

    /// <summary>
    /// Get All Entities
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<TEntity>> GetAll()
    {
        var query = $"select * from {typeof(TEntity).Name}s";
        var entities = await Connection.QueryAsync<TEntity>(query);
        return entities.ToList();
    }

    /// <summary>
    /// Get Entity By Key
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> GetById(long id)
    {
        var query = $"select * from {typeof(TEntity).Name}s where Id=@Id";
        var entity = await Connection.QueryAsync<TEntity>(query, new { Id = id });
        return entity.SingleOrDefault();
    }
    /// <summary>
    /// Get Count of Entities
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetCount()
    {
        var query = $"select count(*) from {typeof(TEntity).Name}s";
        var count = await Connection.ExecuteScalarAsync<int>(query);
        return count;
    }

    protected IEnumerable<string> GetColumns()
    {
        return typeof(TEntity)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
    }
}
