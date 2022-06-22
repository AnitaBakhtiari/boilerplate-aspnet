using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5> : BaseTask<TOutput>,
    ITask5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5);
}