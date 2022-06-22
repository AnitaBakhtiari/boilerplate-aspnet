using System.Linq.Dynamic.Core;
using Core.Message;
using Core.Provider;
using Http.Exception;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAuth_Keycloak.RequestModels;
using OAuth_Keycloak.Services;
using Test.Context;
using Test.Payload;

namespace Test.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("localizationErrorTest")]
    public IActionResult LocalizationErrorTest()
    {
        var badRequestException = new BadRequestException(ResponseExceptionType.EndDateGreaterTHanStartDate);
        throw new BadRequestException("EndDateGreaterTHanStartDate");
    }

    [HttpGet("validationRuleTest")]
    public IActionResult ValidationRuleTest([FromQuery] MyViewModel model)
    {
        return Ok(model);
    }

    [Authorize]
    [HttpGet("getKeyclaokAttribute")]
    public async Task<IActionResult> GetKeyclaokAttribute()
    {
        var users = new List<User>
        {
            new()
            {
                Name = "Anita",
                Family = "Bakhtiari"
            },
            new()
            {
                Name = "Ares",
                Family = "Ornil"
            }
        };

        var accessToken = await HttpContext.GetTokenAsync("access_token");

        if (accessToken == null) return await Task.FromResult<IActionResult>(BadRequest());
        var keycloakApi = ServicesCall.GetService<IKeycloakService>();
        var attributes = await keycloakApi.GetAttributesAsync(new GetAttributesRequestAsync
        {
            Token = accessToken,
            Path = HttpContext.Request.Method
        });
        //var post1 = users.AsQueryable().Where("Name = \"Anita\"").ToList();
        var post = await users.AsQueryable().Where(attributes[0].Condition).ToListAsync();

        return await Task.FromResult<IActionResult>(Ok(post));
    }


}