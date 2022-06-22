namespace Core.Message;

public enum ResponseExceptionType
{
    BadRequest = 400,
    EndDateGreaterTHanStartDate = 4001001,
    InvalidScope = 4001002,


    KeycloakValidateAccessTokenFailed = 4010001,

    InvalidBearerToken = 4030000,

    ActionOrTaskNotFound = 4040000,
    RecourseIdsNotFound = 4040001,

    ValueIsNotValid = 4040002
}