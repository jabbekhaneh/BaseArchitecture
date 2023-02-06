using Portal.Infrastructure.Persistence;

namespace Portal.Web.API.IntegrationTests.Configs;

public class BaseIntegrationTestCreator
{
    private readonly DatabaseContext _context;
    public BaseIntegrationTestCreator(DatabaseContext context)
    {
        _context = context;
    }
}
