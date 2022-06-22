using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask10<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9,
    TInput10> : IBaseTask<TOutput>,
    IProcess10<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9, TInput10>
{
}