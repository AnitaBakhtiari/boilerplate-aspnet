using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask2<TOutput, in TInput1, in TInput2> : IBaseTask<TOutput>, IProcess2<TOutput, TInput1, TInput2>
{
}