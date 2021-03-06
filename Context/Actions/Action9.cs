using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class
    Action9<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9> :
        BaseAction<TOutput>,
        IAction9<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8, TInput9>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5, TInput6 t6, TInput7 t7,
        TInput8 t8, TInput9 t9);
}