namespace Context.Process;

public interface IProcess2<TOutput, in TInput1, in TInput2> : IBaseProcess<TOutput>
{
    TOutput Execute(TInput1 t1, TInput2 t2);
}