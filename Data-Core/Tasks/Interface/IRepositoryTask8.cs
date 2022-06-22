using Context.Tasks.Interface;

namespace DataCore.Tasks.Interface;

public interface IRepositoryTask8<TRepository, TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5,
    in TInput6, in TInput7, TInput8> : IBaseRepositoryTask<TRepository, TOutput>,
    ITask8<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8>
{
}