using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask<TRepository, TOutput> : IBaseRepositoryTask<TRepository, TOutput>, ITask<TOutput>
{
}