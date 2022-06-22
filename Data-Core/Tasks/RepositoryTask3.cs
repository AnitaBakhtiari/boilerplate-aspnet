using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask3<TRepository, TOutput, TInput1, TInput2, TInput3> :
    BaseRepositoryTask<TRepository, TOutput>, IRepositoryTask3<TRepository, TOutput, TInput1, TInput2, TInput3>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3);
}