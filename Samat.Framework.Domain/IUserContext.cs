namespace Samat.Framework.Domain;
public interface IUserContext
{
    UserContextValue? GetCurrentUser();
    long? GetCurrentUserId();
    string? GetCurrentUserFullName();
    string? GetCurrentUserEmail();
    string? GetCurrentUsername();
    string? GetCurrentUserMobile();
    long? GetClientId();
    string? GetClient();
    string? GetPanel();
    string? GetPanelDisplayName();
    long GetPanelId();
    string? GetOSPlatform();
    string? GetToken();
    long? GetAdvocateId();
    string? GetAdvocateFullName();
    bool? IsAdvocate();
    long? GetCurrentUserIdByReadJwtToken();
    string? GetClientByReadJwtToken();
    long? GetCurrentAdvocateIdByReadJwtToken();
    bool? IsAdvocateByReadJwtToken();
    DateTimeOffset? GetTokenExpirationTime();
    bool? IsTokenStored();
    long? GetPartyRole();
    void AddClaims(Dictionary<string, string> claims);
}