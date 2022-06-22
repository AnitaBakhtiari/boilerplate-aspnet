using Context.Tasks.Interface;

namespace Context.Tasks;

public abstract class Task<TOutput> : BaseTask<TOutput>, ITask<TOutput>
{
    public abstract TOutput Execute();
}