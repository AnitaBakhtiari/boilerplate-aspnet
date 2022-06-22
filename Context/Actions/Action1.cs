using Context.Actions.Interfaces;

namespace Context.Actions;

public abstract class Action1<TOutput, TInput> : BaseAction<TOutput>, IAction1<TOutput, TInput>
{
    public abstract TOutput Execute(TInput param);
}