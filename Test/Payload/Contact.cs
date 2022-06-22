using Bread.Attribute;
using Bread.MinimalApi;
using Core.Payload;

namespace Test.Payload;

[Bread(Path = "minimalApi/contacts",
    Methods = ApiMethodsToGenerate.Get | ApiMethodsToGenerate.Delete | ApiMethodsToGenerate.Insert,
    Roles = Roles.admin)]
public class Contact:IPayload
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}