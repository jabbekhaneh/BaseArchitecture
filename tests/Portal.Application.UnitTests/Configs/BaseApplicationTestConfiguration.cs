using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Portal.Application.UnitTests.Configs.Fake;
using Portal.Base.Options;
using Portal.Infrastructure.Persistence;
using Portal.Shared.Identity;
using System.Threading;

namespace Portal.Application.UnitTests.Configs;

public abstract class BaseApplicationTestConfiguration 
{
    protected readonly DatabaseContext DatabaseInMemory;
    protected readonly BaseClaimService _baseClaimService;
    protected readonly CancellationToken _cancellationToken = new CancellationToken();
    protected readonly IOptions<BaseOptions> baseOption = Options.Create<BaseOptions>(new BaseOptions
    {
        UseInMemoryDatabase = true,
    });
    protected DbContextOptions<DatabaseContext> dataBaseOption;
    public BaseApplicationTestConfiguration()
    {

        _baseClaimService = new BaseClaimServiceFake();
        dataBaseOption = new DbContextOptions<DatabaseContext>();

        DatabaseInMemory = new DatabaseContext(dataBaseOption, _baseClaimService, baseOption);
        
    }
}
