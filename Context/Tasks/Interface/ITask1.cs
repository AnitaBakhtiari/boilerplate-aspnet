using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask1<TOutput, in TInput> : IBaseTask<TOutput>, IProcess1<TOutput, TInput>
{
}