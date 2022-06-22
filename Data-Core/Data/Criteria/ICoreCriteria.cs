using DataCore.Data.Repository;

namespace DataCore.Data.Criteria;

public interface ICoreCriteria<TEntity> : ICoreRepository<TEntity> where TEntity : class
//ICoreEntity
{
}