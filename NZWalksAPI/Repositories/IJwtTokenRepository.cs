using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Repositories;

public interface IJwtTokenRepository
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
}