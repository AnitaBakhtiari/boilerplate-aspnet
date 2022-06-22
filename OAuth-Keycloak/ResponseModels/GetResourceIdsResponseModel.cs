namespace OAuth_Keycloak.ResponseModels;

public class GetResourceIdsResponseModel : BaseResponseModel
{
    public object[] ResourceIds { get; set; } = null!;
}