namespace OAuth_Keycloak.RequestModels;

public class GetResourceIdsRequestModel : BaseRequestModel
{
    public string Path { get; set; } = null!;
}