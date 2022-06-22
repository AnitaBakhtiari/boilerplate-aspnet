using DataCore.Data.Repository;

namespace DataSql.Data.Repository;

public interface IBaseQuerydslRepository<TEntity> : ICoreQueryRepository<TEntity> where TEntity : class
{
}