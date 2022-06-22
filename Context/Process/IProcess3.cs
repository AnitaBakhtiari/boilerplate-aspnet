namespace Context.Process;

public interface IProcess3<TOutput, in TInput1, in TInput2, in TInput3> : IBaseProcess<TOutput>
{
    TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3);
}