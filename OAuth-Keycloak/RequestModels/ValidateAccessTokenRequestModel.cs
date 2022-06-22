namespace OAuth_Keycloak.RequestModels;

public class ValidateAccessTokenRequestModel : BaseRequestModel
{
    public List<KeyValuePair<string, string>>? BodyList { get; set; }
}