namespace Portal.Base.CQRS.Query;


public interface BaseQueryRepository<TEntity>
{
    Task<TEntity> GetById(long id);
    Task<ICollection<TEntity>> GetAll();
    Task<int> GetCount();
    
}
