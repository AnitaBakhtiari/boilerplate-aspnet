using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace Test.Payload;

[AutoMap(typeof(User))]
public class UserResponse
{
    [SourceMember(nameof(User.Id))] public string? UserId { get; set; }

    public string? Name { get; set; }
    public string? Family { get; set; }
}