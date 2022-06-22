using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask3<TOutput, in TInput1, in TInput2, in TInput3> : IBaseTask<TOutput>,
    IProcess3<TOutput, TInput1, TInput2, TInput3>
{
}