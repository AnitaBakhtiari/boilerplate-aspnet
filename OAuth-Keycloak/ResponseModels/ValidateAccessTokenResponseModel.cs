namespace OAuth_Keycloak.ResponseModels;

public class ValidateAccessTokenResponseModel : BaseResponseModel
{
    public bool IsValid { get; set; }
    public string Path { get; set; } = null!;
}