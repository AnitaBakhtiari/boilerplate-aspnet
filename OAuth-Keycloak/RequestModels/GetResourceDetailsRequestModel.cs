namespace OAuth_Keycloak.RequestModels;

public class GetResourceDetailsRequestModel : BaseRequestModel
{
    public object ResourceId { get; set; } = null!;
    public string Path { get; set; } = null!;
}