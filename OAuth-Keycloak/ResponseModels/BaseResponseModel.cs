using Newtonsoft.Json;

namespace OAuth_Keycloak.ResponseModels;

public class BaseResponseModel
{
    [JsonIgnore] public bool IsSuccess { get; set; }

    [JsonIgnore] public int StatusCode { get; set; }

    [JsonProperty("error")] public string? Error { get; set; }


    [JsonProperty("error_description")] public string? ErrorDescription { get; set; }
}