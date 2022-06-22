using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask10<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7,
    TInput8, TInput9, TInput10> : IBaseRepositoryTask<TRepository, TOutput>,
    ITask10<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9, TInput10>
{
}