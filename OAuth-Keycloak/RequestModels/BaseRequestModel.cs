using Newtonsoft.Json;

namespace OAuth_Keycloak.RequestModels;

public class BaseRequestModel
{
    [JsonIgnore] public string Token { get; set; } = null!;
}