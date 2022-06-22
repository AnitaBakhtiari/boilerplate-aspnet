using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IBaseRepositoryTask<TRepository, TOutput> : IBaseTask<TOutput>
{
}