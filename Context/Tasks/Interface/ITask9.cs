using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask9<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5, in TInput6, in TInput7,
    in TInput8, in TInput9> : IBaseTask<TOutput>,
    IProcess9<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9>
{
}