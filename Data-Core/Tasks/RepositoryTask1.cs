using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask1<TRepository, TOutput, TInput> : BaseRepositoryTask<TRepository, TOutput>,
    IRepositoryTask1<TRepository, TOutput, TInput>
{
    public abstract TOutput Execute(TInput param);
}