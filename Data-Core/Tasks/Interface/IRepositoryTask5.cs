using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask5<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5> :
    IBaseRepositoryTask<TRepository, TOutput>, ITask5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
}