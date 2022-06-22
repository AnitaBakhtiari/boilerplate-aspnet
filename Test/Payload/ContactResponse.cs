using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace Test.Payload;

[AutoMap(typeof(Contact))]
public class ContactResponse
{
    [SourceMember(nameof(Contact.Id))] public int ContactId { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
}