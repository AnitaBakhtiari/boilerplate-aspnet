using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction5<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5> : IBaseAction<TOutput>,
    IProcess5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
}