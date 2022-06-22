namespace Context.Process;

public interface IProcess1<TOutput, in TInput> : IBaseProcess<TOutput>
{
    TOutput Execute(TInput param);
}