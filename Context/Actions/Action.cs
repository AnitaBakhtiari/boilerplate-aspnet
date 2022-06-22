using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action<TOutput> : BaseAction<TOutput>, IAction<TOutput>
{
    public abstract TOutput Execute();
}