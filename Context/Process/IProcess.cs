namespace Context.Process;

public interface IProcess<TOutput> : IBaseProcess<TOutput>
{
    TOutput Execute();
}