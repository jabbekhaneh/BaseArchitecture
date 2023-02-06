using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Portal.Base.Entities;
using Portal.Base.Options;
using Portal.Domain.Localization;
using Portal.Infrastructure.Identity;
using Portal.Shared.Identity;
using System.Reflection;
namespace Portal.Infrastructure.Persistence;
public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    private IOptions<BaseOptions> _baseOptions;
    private readonly BaseClaimService _claimService;
    public DatabaseContext(DbContextOptions options, BaseClaimService claimService, IOptions<BaseOptions> baseOptions) : base(options)
    {
        _claimService = claimService;
        _baseOptions = baseOptions;
    }

    public DbSet<Language> Languages { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_baseOptions.Value.UseInMemoryDatabase)
        {
            optionsBuilder.UseInMemoryDatabase("dbInMemory");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
        else
        {

            optionsBuilder.UseSqlServer(_baseOptions.Value.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }
    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        if (_claimService.IsAuthenticated())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Create(_claimService.GetUserId());
                        break;
                    case EntityState.Modified:
                        entry.Entity.Update(_claimService.GetUserId());
                        break;
                }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}