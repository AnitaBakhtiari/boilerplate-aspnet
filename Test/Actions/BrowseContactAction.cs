using Context.Actions;
using Core.Provider;
using Test.Payload;
using Test.Tasks;

namespace Test.Actions;

public class BrowseContactAction : Action1<ContactResponse, int>
{
    [Cache.Attribute.Cache(Seconds = 30, Key = "param")]
    public override ContactResponse Execute(int param)
    {
        return ServicesCall.Call<BrowseContactTask, ContactResponse, int>(param);
    }
}