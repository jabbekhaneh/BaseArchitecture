using Microsoft.EntityFrameworkCore;
using Portal.Base.CQRS.Command;
using Portal.Base.Entities;
namespace Portal.Infrastructure.Persistence.Repositories;

public class EFRepository<TEntity> : BaseCammandRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> DbSet;
    public EFRepository(DatabaseContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;

        return addedEntity;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);

    }

    public TEntity Update(TEntity entity)
    {
        var updateEntity = (DbSet.Update(entity)).Entity;
        return updateEntity;
    }

    public async Task InsertBulk(List<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task DeleteById(long id)
    {
        var entity = await DbSet.Where(_=>_.Id.Equals(id)).FirstOrDefaultAsync();
         if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        DbSet.Remove(entity);
    }

    public async Task<TEntity> FindById(long id)
    {
        return await DbSet.FindAsync(id);
    }
}