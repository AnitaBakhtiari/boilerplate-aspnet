using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction2<TOutput, in TInput1, in TInput2> : IBaseAction<TOutput>, IProcess2<TOutput, TInput1, TInput2>
{
}