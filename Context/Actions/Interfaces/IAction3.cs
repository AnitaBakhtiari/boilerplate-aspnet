using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction3<TOutput, in TInput1, in TInput2, in TInput3> : IBaseAction<TOutput>,
    IProcess3<TOutput, TInput1, TInput2, TInput3>
{
}