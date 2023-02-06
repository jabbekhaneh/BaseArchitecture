namespace Portal.Shared.Identity;

public interface BaseClaimService
{
    string GetUserId();
    string GetClaim(string key);
    bool IsAuthenticated();
}
