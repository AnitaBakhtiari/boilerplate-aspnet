namespace DataCore.Data.Repository;

public interface ICoreRepository<TEntity> where TEntity : class /*: JpaRepository<TEntity, string> where TEntity : ICoreEntity*/
{
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
    
    TEntity Add(TEntity entity);
    Task<TEntity> GetAsync(long id);
    Task<TEntity> DeleteAsync(long id);
    TEntity Update(TEntity entity);
    IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
    TEntity Delete(TEntity entity);
    Task<IEnumerable<TEntity>> GetListAsync();
    Task<long> CountAsync { get; }
    Task SaveChangesAsync();
}