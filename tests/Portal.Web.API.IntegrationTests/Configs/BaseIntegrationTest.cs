using Microsoft.Extensions.DependencyInjection;
using Portal.Infrastructure.Persistence;
using Xunit;



namespace Portal.Web.API.IntegrationTests.Configs;

public class BaseIntegrationTest : IClassFixture<IntegrationTestFactory<Program, DatabaseContext>>
{
    public readonly IntegrationTestFactory<Program, DatabaseContext> Factory;
    public readonly DatabaseContext DbContext;

    public BaseIntegrationTest(IntegrationTestFactory<Program, DatabaseContext> factory)
    {
        Factory = factory;
        var scope = factory.Services.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    }
}
