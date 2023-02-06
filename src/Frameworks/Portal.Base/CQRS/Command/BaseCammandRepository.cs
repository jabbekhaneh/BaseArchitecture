namespace Portal.Base.CQRS.Command;

public interface BaseCammandRepository<TEntity>
{
    Task<TEntity> Insert(TEntity entity);
    Task InsertBulk(List<TEntity> entities);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteById(long id);
    Task<TEntity> FindById(long id);
}
