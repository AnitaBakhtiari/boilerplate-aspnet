using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask<TRepository, TOutput> : BaseRepositoryTask<TRepository, TOutput>,
    IRepositoryTask<TRepository, TOutput>
{
    public abstract TOutput Execute();
}