namespace Context.Process;

public interface IProcess10<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5, in TInput6, in TInput7,
    in TInput8, in TInput9, in TInput10> : IBaseProcess<TOutput>
{
    TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5, TInput6 t6, TInput7 t7, TInput8 t8,
        TInput9 t9, TInput10 t10);
}