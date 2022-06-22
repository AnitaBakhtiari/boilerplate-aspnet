using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task2<TOutput, TInput1, TInput2> : BaseTask<TOutput>, ITask2<TOutput, TInput1, TInput2>
{
    public abstract TOutput Execute(TInput1 param1, TInput2 param2);

    public System.Threading.Tasks.Task<TOutput> ExecuteAsync(TInput1 t1, TInput2 t2)
    {
        throw new NotImplementedException();
    }
}