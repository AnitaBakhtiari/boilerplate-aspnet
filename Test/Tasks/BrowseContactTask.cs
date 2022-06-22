using DataCore.Tasks;
using Test.Payload;
using Test.Repository;

namespace Test.Tasks;

public class BrowseContactTask : RepositoryTask1<IContactRepository, ContactResponse, int>
{
    public override ContactResponse Execute(int param)
    {
        return GetRepository().GetById(param);
    }
}