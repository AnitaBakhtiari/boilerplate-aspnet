using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask7<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7> :
    IBaseRepositoryTask<TRepository, TOutput>,
    ITask7<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7>
{
}