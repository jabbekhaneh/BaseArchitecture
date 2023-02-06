using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace Portal.Shared.Identity.Impl;

public class ClaimService  :BaseClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId()
    {
        return GetClaim(ClaimTypes.NameIdentifier);
    }

    public string GetClaim(string key)
    {
        
        return _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value;
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
