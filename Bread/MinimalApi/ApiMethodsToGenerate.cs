namespace Bread.MinimalApi;

[Flags]
public enum ApiMethodsToGenerate
{
    Get = 1,
    GetById = 2,
    Insert = 4,
    Update = 8,
    Delete = 16,
    All = 31
}

public record TableApiMapping(
    string TableName,
    ApiMethodsToGenerate MethodsToGenerate = ApiMethodsToGenerate.All,
    Roles Roles = Roles.administrators1,
    string BaseUrl = ""
);

[AttributeUsage(AttributeTargets.Method)]
public class ApiMethodAttribute : System.Attribute
{
    public ApiMethodAttribute(ApiMethodsToGenerate apiMethodsToGenerate)
    {
        MethodsToGenerate = apiMethodsToGenerate;
    }

    public ApiMethodsToGenerate MethodsToGenerate { get; set; }
}

[Flags]
public enum Roles
{
    administrators1 = 0,
    admin
}