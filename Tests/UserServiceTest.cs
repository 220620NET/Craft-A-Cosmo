using Moq;
using DataAccess.Entities;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;


namespace Tests;

public class UserServiceTests
{

    //these are bad and need review

    [Fact]
    public async Task GetUserByEmail()
    {
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",

        };

        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserByEmail(newUser.Email)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);

        var existingUser = await service.GetUserByEmail(newUser.Email);

        Assert.Equal(newUser.Email, existingUser.Email);
    }

    [Fact]
    public async Task GetUserByUserId()
    {
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",
        };

        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserByUserId(newUser.UserId)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);

        var existingUser = await service.GetUserByUserId(newUser.UserId);

        Assert.Equal(newUser.UserId, existingUser.UserId);
    }

    [Fact]
    public async Task GetUserByUsername()
    {
        var mockUser = new Mock<IUserRepo>();

        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",
        };
        
        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserByUsername(newUser.Username)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);


        var existingUser = await service.GetUserByUsername(newUser.Username);

        Assert.Equal(newUser.Username, existingUser.Username);
    }
}