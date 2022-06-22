using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction<TOutput> : IBaseAction<TOutput>, IProcess<TOutput>
{
}