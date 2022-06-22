using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask4<TOutput, in TInput1, in TInput2, in TInput3, in TInput4> : IBaseTask<TOutput>,
    IProcess4<TOutput, TInput1, TInput2, TInput3, TInput4>
{
}