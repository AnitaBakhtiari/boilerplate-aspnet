using Context.Process;

namespace Context.Tasks.Interface;

public interface ITask5<TOutput, in TInput1, in TInput2, in TInput3, in TInput4, in TInput5> : IBaseTask<TOutput>,
    IProcess5<TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
}