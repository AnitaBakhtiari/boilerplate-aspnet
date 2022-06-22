using Context.Process;

namespace Context.Actions.Interfaces;

public interface IAction7<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5, in TInput6, in TInput7> :
    IBaseAction<TOutput>, IProcess7<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7>
{
}