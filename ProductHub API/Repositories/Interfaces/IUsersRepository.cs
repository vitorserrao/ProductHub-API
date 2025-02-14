using ProductHub_API.Models;

namespace ProductHub_API.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<UsersModel?> GetByUserName(string userName);
        Task Add(UsersModel user);
    }
}
