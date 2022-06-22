using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask5<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5> :
    BaseRepositoryTask<TRepository, TOutput>,
    IRepositoryTask5<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5);
}