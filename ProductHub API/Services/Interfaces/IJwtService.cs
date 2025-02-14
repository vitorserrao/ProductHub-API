using ProductHub_API.Models;

namespace ProductHub_API.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(UsersModel user);
    }
}
