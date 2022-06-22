using Core.Message;
using Core.Metadata;
using Http.Exception;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using OAuth_Keycloak.Extensions;
using OAuth_Keycloak.RequestModels;
using OAuth_Keycloak.ResponseModels;

namespace OAuth_Keycloak.Services;

public class KeycloakService : IKeycloakService
{
    private const string ResourceUrl = "http://localhost:8080/auth/realms/master/authz/protection/resource_set";
    private const string AccessTokenUrl = "http://localhost:8080/auth/realms/master/protocol/openid-connect/token";
    private const string UserInfo = "http://localhost:8080/auth/realms/master/protocol/openid-connect/userinfo";
    private const string Authorization = "Authorization";
    private const string Audience = "demo-app";
    private const string GrantTypeValue = "urn:ietf:params:oauth:grant-type:uma-ticket";
    private const string MatchingUriValue = "true";
    private readonly HttpClient _httpClient;
    private readonly IOptions<KeycloakOption> _options;

    public KeycloakService(HttpClient httpClient, IOptions<KeycloakOption> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<GetResourceIdsResponseModel> GetResourceIdsAsync(GetResourceIdsRequestModel model)
    {
        SetAuthorizeHeader(model.Token);
        var requestMessage = new HttpRequestMessage(new HttpMethod(MethodEnum.GET.GetDisplayName()), ResourceUrl);
        var postParams = new Dictionary<string, string> {{"matchingUri", MatchingUriValue}, {"uri", $"{model.Path}"}};
        requestMessage.Content = new FormUrlEncodedContent(postParams);
        var response = _httpClient.SendAsync(requestMessage).Result;

        if (!response.IsSuccessStatusCode) return await HandleResponse<GetResourceIdsResponseModel>(response);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<object[]>(data);

        if (result != null)
            return new GetResourceIdsResponseModel {ResourceIds = result, IsSuccess = true};

        return await HandleResponse<GetResourceIdsResponseModel>(response);
    }

    public async Task<ResourceDetailsResponseModel> GetResourceDetailsByIdAsync(GetResourceDetailsRequestModel model)
    {
        SetAuthorizeHeader(model.Token);

        var requestMessage = new HttpRequestMessage(new HttpMethod(MethodEnum.GET.GetDisplayName()),
            ResourceUrl + "/" + model.ResourceId);
        var postParams = new Dictionary<string, string> {{"matchingUri", MatchingUriValue}, {"uri", $"{model.Path}"}};
        requestMessage.Content = new FormUrlEncodedContent(postParams);
        var result = _httpClient.SendAsync(requestMessage).Result;


        return await HandleResponse<ResourceDetailsResponseModel>(result);
    }

    public async Task<UserInfoResponseModel> GetUserInfoAsync(BaseRequestModel model)
    {
        SetAuthorizeHeader(model.Token);
        var requestMessage = new HttpRequestMessage(new HttpMethod(MethodEnum.GET.GetDisplayName()), UserInfo);
        var result = _httpClient.SendAsync(requestMessage).Result;

        return await HandleResponse<UserInfoResponseModel>(result);
    }

    public async Task<ValidateAccessTokenResponseModel> ValidateAccessTokenAsync(ValidateAccessTokenRequestModel model)
    {
        var content = new List<KeyValuePair<string, string>>
        {
            new("audience", _options.Value.ValidAudience), new("grant_type", GrantTypeValue)
        };

        content.AddRange(model.BodyList!);

        SetAuthorizeHeader(model.Token);
        var requestMessage = new HttpRequestMessage(new HttpMethod(MethodEnum.POST.GetDisplayName()), AccessTokenUrl);
        requestMessage.Content = new FormUrlEncodedContent(content);
        var result = _httpClient.SendAsync(requestMessage).Result;

        return await HandleResponse<ValidateAccessTokenResponseModel>(result);
    }

    public async Task<List<GetAttributesResponseModel>> GetAttributesAsync(GetAttributesRequestAsync model)
    {
        var user = await GetUserInfoAsync(new BaseRequestModel {Token = model.Token});

        var getResourceIds = await GetResourceIdsAsync(new GetResourceIdsRequestModel
        {
            Path = model.Path,
            Token = model.Token
        })!;

        if (!getResourceIds.IsSuccess)
            throw new UnauthorizedException(ResponseExceptionType.InvalidBearerToken);

        var attributeList = new List<GetAttributesResponseModel>();

        foreach (var resourceId in getResourceIds.ResourceIds)
        {
            var getResourceDetails = await GetResourceDetailsByIdAsync(new GetResourceDetailsRequestModel
            {
                ResourceId = resourceId,
                Token = model.Token
            });

            if (getResourceDetails.Attributes.Condition == null) continue;

            var result = getResourceDetails?.Attributes.Condition.FirstOrDefault()!.ReplaceNameTags(user);

            attributeList.Add(new GetAttributesResponseModel(result!));
        }

        return attributeList;
    }

    private void SetAuthorizeHeader(string? token)
    {
        var hasAuthorizationHeader = _httpClient.DefaultRequestHeaders.TryGetValues(Authorization, out var value);
        if(hasAuthorizationHeader || string.IsNullOrEmpty(token)) _httpClient.DefaultRequestHeaders.Remove(Authorization);
       // if (!hasAuthorizationHeader && !string.IsNullOrEmpty(token))
            _httpClient.DefaultRequestHeaders.Add(Authorization,/* "Bearer " + */ token);
    }

    private static async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response) where TResponse : new()
    {
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(data);
            result?.GetType().GetProperty(nameof(BaseResponseModel.IsSuccess))?.SetValue(result, true);
            result?.GetType().GetProperty(nameof(BaseResponseModel.StatusCode))?.SetValue(result, response.StatusCode);

            if (result != null) return result;
        }


        var apiResultString = await response.Content.ReadAsStringAsync();
        var apiResult = JsonConvert.DeserializeObject<TResponse>(apiResultString);
        apiResult?.GetType().GetProperty(nameof(BaseResponseModel.StatusCode))
            ?.SetValue(apiResult, response.StatusCode);

        return apiResult!;
    }
}