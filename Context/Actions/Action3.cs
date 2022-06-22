using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action3<TOutput, TInput1, TInput2, TInput3> : BaseAction<TOutput>,
    IAction3<TOutput, TInput1, TInput2, TInput3>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3);
}