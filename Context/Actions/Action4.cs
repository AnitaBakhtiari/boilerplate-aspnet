using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action4<TOutput, TInput1, TInput2, TInput3, TInput4> : BaseAction<TOutput>,
    IAction4<TOutput, TInput1, TInput2, TInput3, TInput4>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4);
}