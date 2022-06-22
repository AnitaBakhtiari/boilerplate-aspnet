using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface
    IRepositoryTask2<TRepository, TOutput, in TInput1, in TInput2> : IBaseRepositoryTask<TRepository, TOutput>,
        ITask2<TOutput, TInput1, TInput2>
{
}