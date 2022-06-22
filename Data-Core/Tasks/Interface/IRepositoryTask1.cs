using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask1<TRepository, TOutput, in TInput> : IBaseRepositoryTask<TRepository, TOutput>,
    ITask1<TOutput, TInput>
{
}