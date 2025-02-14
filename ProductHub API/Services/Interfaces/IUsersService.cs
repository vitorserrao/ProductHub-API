using ProductHub_API.Dto.Users;
using ProductHub_API.Models;

namespace ProductHub_API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseModel<UsersModel>> CreateUser(UsersDto usersDto);
        Task<ResponseModel<string>> Login(UsersDto usersDto);

    }
}
