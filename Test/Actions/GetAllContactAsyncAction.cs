using Context.Actions;
using Core.Provider;
using Test.Payload;
using Test.Tasks;
using Util.Paging;

namespace Test.Actions;

public class GetAllContactAsyncAction : Action2<Task<Page<ContactResponse>>, int, int>
{
    public override async Task<Page<ContactResponse>> Execute(int size, int page)
    {
        return await ServicesCall.CallAsync<GetAllContactAsyncTask, Page<ContactResponse>, int, int>(size, page);
    }
}