using Bread.MinimalApi;

namespace Bread.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class BreadAttribute : System.Attribute
{
    public string Path { get; set; } = "BaseUrl";
    public ApiMethodsToGenerate Methods { get; set; }
    public Roles Roles { get; set; }
}