using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask2<TRepository, TOutput, TInput1, TInput2> :
    BaseRepositoryTask<TRepository, TOutput>, IRepositoryTask2<TRepository, TOutput, TInput1, TInput2>
{
    public abstract TOutput Execute(TInput1 param1, TInput2 param2);

    public Task<TOutput> ExecuteAsync(TInput1 t1, TInput2 t2)
    {
        throw new NotImplementedException();
    }
}