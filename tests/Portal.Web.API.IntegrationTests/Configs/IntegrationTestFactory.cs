using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portal.Web.API.IntegrationTests.Configs;

public class IntegrationTestFactory<TProgram, TDbContext> : WebApplicationFactory<TProgram>
    where TProgram : class where TDbContext : DbContext
{

    private string _connectionString = "";
    public IntegrationTestFactory()
    {
        
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<TDbContext>();
            services.AddDbContext<TDbContext>(options => { options.UseSqlServer(_connectionString); });
            services.AddTransient<BaseIntegrationTestCreator>();
        });
    }

    //public async Task InitializeAsync() => await _container.StartAsync();

    //public new async Task DisposeAsync() => await _container.DisposeAsync();
}


public static class ServiceCollectionExtensions
{
    public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
        if (descriptor != null) services.Remove(descriptor);
    }

    public static void EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
    {
        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var context = scopedServices.GetRequiredService<T>();
        context.Database.EnsureCreated();
    }
}

