using Context.Process;

namespace Context.Actions.Interfaces;

public interface
    IAction6<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5, in TInput6> : IBaseAction<TOutput>,
        IProcess6<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>
{
}