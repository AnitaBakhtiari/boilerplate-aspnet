namespace OAuth_Keycloak.ResponseModels;

public class ResourceDetailsResponseModel : BaseResponseModel
{
    public string Name { get; set; } = null!;
    public Owner Owner { get; set; } = null!;
    public bool OwnerManagedAccess { get; set; }
    public Attributes Attributes { get; set; } = null!;
}

public class Owner
{
    public string Id { get; set; } = null!;
}

public class Attributes
{
    public string[]? Condition { get; set; } = null!;
}