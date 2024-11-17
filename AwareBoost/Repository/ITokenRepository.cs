using AwareBoost.Models;
using Microsoft.AspNetCore.Identity;

namespace AwareBoost.Repository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
        RefreshToken GenerateRefreshToken();
        void SetRefreshToken(RefreshToken newRefreshToken);
    }
}
