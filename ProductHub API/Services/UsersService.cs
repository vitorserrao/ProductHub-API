using BCrypt.Net;
using ProductHub_API.Dto.Users;
using ProductHub_API.Models;
using ProductHub_API.Repositories.Interfaces;
using ProductHub_API.Services.Interfaces;

namespace ProductHub_API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtService _jwtService;


        public UsersService(IUsersRepository usersRepository, IJwtService jwtService    )
        {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
        }

        public async Task<ResponseModel<UsersModel>> CreateUser(UsersDto usersDto)
        {
            ResponseModel<UsersModel> response = new ResponseModel<UsersModel>();

            try
            {
                var existingUser = await _usersRepository.GetByUserName(usersDto.UserName);
                if (existingUser != null)
                {
                    response.Message = "Usuário já existe!";
                    response.Status = false;
                    return response;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usersDto.PasswordHash);

                var newUser = new UsersModel()
                {
                    UserName = usersDto.UserName,
                    PasswordHash = hashedPassword 
                };

                await _usersRepository.Add(newUser);
                response.Message = "Usuário criado com sucesso!";
                response.Data = newUser;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<string>> Login(UsersDto usersDto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var user = await _usersRepository.GetByUserName(usersDto.UserName);
                if (user == null || !BCrypt.Net.BCrypt.Verify(usersDto.PasswordHash, user.PasswordHash))
                {
                    response.Message = "Usuário ou senha inválidos!";
                    response.Status = false;
                    return response;
                }

                string token = _jwtService.GenerateJwtToken(user);

                response.Message = "Login realizado com sucesso!";
                response.Status = true;
                response.Data = token;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;
        }
    }
}
