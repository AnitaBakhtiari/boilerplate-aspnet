namespace Context.Process;

public interface
    IProcess6<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5, in TInput6> : IBaseProcess<TOutput>
{
    TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5, TInput6 t6);
}