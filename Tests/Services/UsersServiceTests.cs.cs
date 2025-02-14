using Moq;
using Xunit;
using ProductHub_API.Services;
using ProductHub_API.Services.Interfaces;
using ProductHub_API.Repositories.Interfaces;
using ProductHub_API.Models;
using ProductHub_API.Dto.Users;
using System.Threading.Tasks;

public class UsersServiceTests
{
    private readonly UsersService _usersService;
    private readonly Mock<IUsersRepository> _usersRepositoryMock;
    private readonly Mock<IJwtService> _jwtServiceMock;

    public UsersServiceTests()
    {
        _usersRepositoryMock = new Mock<IUsersRepository>();
        _jwtServiceMock = new Mock<IJwtService>();
        _usersService = new UsersService(_usersRepositoryMock.Object, _jwtServiceMock.Object);
    }

    [Fact]
    public async Task CreateUser_ShouldReturnError_WhenUserAlreadyExists()
    {
        var existingUser = new UsersModel { UserName = "admin", PasswordHash = "hashed" };
        _usersRepositoryMock.Setup(r => r.GetByUserName("admin")).ReturnsAsync(existingUser);

        var newUserDto = new UsersDto { UserName = "admin", PasswordHash = "123456" };

        var result = await _usersService.CreateUser(newUserDto);

        Assert.False(result.Status);
        Assert.Equal("Usuário já existe!", result.Message);
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var user = new UsersModel { Id = 1, UserName = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456") };
        _usersRepositoryMock.Setup(r => r.GetByUserName("admin")).ReturnsAsync(user);
        _jwtServiceMock.Setup(j => j.GenerateJwtToken(user)).Returns("fake-jwt-token");

        var loginDto = new UsersDto { UserName = "admin", PasswordHash = "123456" };

        // Act
        var result = await _usersService.Login(loginDto);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("fake-jwt-token", result.Data);
    }
}
