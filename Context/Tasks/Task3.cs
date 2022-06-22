using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task3<TOutput, TInput1, TInput2, TInput3> : BaseTask<TOutput>,
    ITask3<TOutput, TInput1, TInput2, TInput3>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3);
}