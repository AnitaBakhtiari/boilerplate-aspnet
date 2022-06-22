using OAuth_Keycloak.RequestModels;
using OAuth_Keycloak.ResponseModels;

namespace OAuth_Keycloak.Services;

public interface IKeycloakService
{
    Task<GetResourceIdsResponseModel> GetResourceIdsAsync(GetResourceIdsRequestModel model);
    Task<ResourceDetailsResponseModel> GetResourceDetailsByIdAsync(GetResourceDetailsRequestModel model);
    Task<UserInfoResponseModel> GetUserInfoAsync(BaseRequestModel model);
    Task<ValidateAccessTokenResponseModel> ValidateAccessTokenAsync(ValidateAccessTokenRequestModel model);
    Task<List<GetAttributesResponseModel>> GetAttributesAsync(GetAttributesRequestAsync model);
}