using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface
    IRepositoryTask3<TRepository, TOutput, TInput1, TInput2, TInput3> : IBaseRepositoryTask<TRepository, TOutput>,
        ITask3<TOutput, TInput1, TInput2, TInput3>
{
}