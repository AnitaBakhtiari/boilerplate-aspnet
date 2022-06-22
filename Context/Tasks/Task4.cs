using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task4<TOutput, TInput1, TInput2, TInput3, TInput4> : BaseTask<TOutput>,
    ITask4<TOutput, TInput1, TInput2, TInput3, TInput4>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4);
}