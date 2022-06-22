namespace OAuth_Keycloak.ResponseModels;

public class GetAttributesResponseModel
{
    public GetAttributesResponseModel(string condition)
    {
        Condition = condition;
    }

    public string Condition { get; set; }
}