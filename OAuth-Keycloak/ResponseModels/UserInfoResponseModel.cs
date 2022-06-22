using Newtonsoft.Json;

namespace OAuth_Keycloak.ResponseModels;

public class UserInfoResponseModel : BaseResponseModel
{
    public string Sub { get; set; } = null!;

    [JsonProperty("email_verified")] public bool EmailVerified { get; set; }

    [JsonProperty("preferred_username")] public string PreferredUserName { get; set; } = null!;

    public int Age { get; set; }
}