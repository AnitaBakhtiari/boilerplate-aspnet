using Context.Tasks;
using Core.Provider;
using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public class BaseRepositoryTask<TRepository, TOutput> : BaseTask<TOutput>, /* MapperPagingModel<TOutput>,*/
    IBaseRepositoryTask<TRepository, TOutput>
{
    protected TRepository GetRepository()
    {
        return ServicesCall.GetService<TRepository>();
    }
}