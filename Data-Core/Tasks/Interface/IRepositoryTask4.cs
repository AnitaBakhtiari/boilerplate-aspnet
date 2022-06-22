using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask4<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4> :
    IBaseRepositoryTask<TRepository, TOutput>, ITask4<TOutput, TInput1, TInput2, TInput3, TInput4>
{
}