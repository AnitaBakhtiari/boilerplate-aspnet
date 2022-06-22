using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5> : BaseAction<TOutput>,
    IAction5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5);
}