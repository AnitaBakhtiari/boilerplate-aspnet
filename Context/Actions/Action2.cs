using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action2<TOutput, TInput1, TInput2> : BaseAction<TOutput>, IAction2<TOutput, TInput1, TInput2>
{
    public abstract TOutput Execute(TInput1 param1, TInput2 param2);
}