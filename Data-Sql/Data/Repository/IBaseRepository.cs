using DataCore.Data.Repository;

namespace DataSql.Data.Repository;

public interface IBaseRepository<TEntity> : ICoreRepository<TEntity>, IBaseQuerydslRepository<TEntity>
    where TEntity : class
{
}