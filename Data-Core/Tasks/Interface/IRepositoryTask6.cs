using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask6<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6> :
    IBaseRepositoryTask<TRepository, TOutput>, ITask6<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>
{
}