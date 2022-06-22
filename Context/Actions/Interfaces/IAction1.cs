using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction1<TOutput, in TInput> : IBaseAction<TOutput>, IProcess1<TOutput, TInput>
{
}