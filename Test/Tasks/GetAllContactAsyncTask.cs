using DataCore.Tasks;
using Test.Payload;
using Test.Repository;
using Util.Paging;
  
namespace Test.Tasks;

public class GetAllContactAsyncTask : RepositoryTask2<IContactRepository, Task<Page<ContactResponse>>, int, int>
{
    public override async Task<Page<ContactResponse>> Execute(int size, int page)
    {
        return await GetRepository().GetAllAsync(size, page);
    }
}