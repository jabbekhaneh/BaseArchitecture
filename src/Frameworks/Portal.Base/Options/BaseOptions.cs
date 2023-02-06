

namespace Portal.Base.Options;

public class BaseOptions
{
    public BaseOptions()
    {
        ConnectionString = $"data source ={DataSource}; initial catalog ={DatabaseName}; integrated security = {IntegratedSecurity}; MultipleActiveResultSets={MultipleActiveResultSets}";
    }
    public string ConnectionString { get; private set; } = string.Empty;
    public string DatabaseName { get; set; } = "dbCMS";
    public string SchemaName { get; set; } = "dbo";
    public string DataSource { get; set; } = ".";
    public string IntegratedSecurity { get; set; } = "True";
    public string MultipleActiveResultSets { get; set; } = "True";
    public bool UseInMemoryDatabase { get; set; } = false;
    public string InMemoryDatabaseConnection { get; private set; } =
        @"Data Source=app.db"; 
    
}

