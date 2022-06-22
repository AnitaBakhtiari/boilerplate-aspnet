using Core.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Actions;
using Test.Payload;
using Util.Paging;

namespace Test.Controllers;

[ApiController]
[Route("[controller]/contacts")]
public class ContactController : ControllerBase
{
     [Authorize]
    //[AuthorizationPolicyFilter(MethodEnum.GET)]
    [HttpGet("{id:int}")]
    public IActionResult GetContactById(int id)
    {
        return Ok(ServicesCall.Call<BrowseContactAction, object, int>(id));
    }


    [HttpGet]
    public async Task<IActionResult> GetAllContactAsync(int size, int page)
    {
        return Ok(await ServicesCall.CallAsync<GetAllContactAsyncAction, Page<ContactResponse>, int, int>(size, page));
    }
}