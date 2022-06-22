using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task1<TOutput, TInput> : BaseTask<TOutput>, ITask1<TOutput, TInput>
{
    public abstract TOutput Execute(TInput param);
}