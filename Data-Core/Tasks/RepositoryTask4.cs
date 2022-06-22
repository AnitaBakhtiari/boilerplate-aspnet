using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask4<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4> :
    BaseRepositoryTask<TRepository, TOutput>, IRepositoryTask4<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4);
}