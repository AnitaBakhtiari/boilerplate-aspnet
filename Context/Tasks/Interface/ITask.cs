using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask<TOutput> : IBaseTask<TOutput>, IProcess<TOutput>
{
}