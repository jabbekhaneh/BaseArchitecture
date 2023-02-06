using Portal.Base.CQRS.Command;

namespace Portal.Infrastructure.Persistence.Repositories;

public class EFUnitOfWork : BaseCammandUnitOfWork
{
    private readonly DatabaseContext _dbContext;
    public EFUnitOfWork(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }
}
