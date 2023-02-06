using Portal.Shared.Identity;
using System;

namespace Portal.Application.UnitTests.Configs.Fake;

public class BaseClaimServiceFake : BaseClaimService
{
    public string GetClaim(string key)
    {
        return "Dummy-Claim";
    }

    public string GetUserId()
    {
        return Guid.NewGuid().ToString();
    }

    public bool IsAuthenticated()
    {
        return false;
    }
}
