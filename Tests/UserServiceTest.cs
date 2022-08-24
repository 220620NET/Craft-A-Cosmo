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
    public async Task GetUserById()
    {
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserID = 2,
            Email = "merp@merp.com",
            username = "merple",
        };

        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserById(newUser.UserID)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);

        var existingUser = await service.GetUserById(newUser.UserID);

        Assert.Equal(newUser.UserID, existingUser.UserID);
    }

    [Fact]
    public void GetUserByUsername()
    {
        var mockUser = new Mock<IUserRepo>

        User newUser = new User{
            UserID = 2,
            Email = "merp@merp.com",
            username = "merple",
        }
        
        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserById(newUser.UserID)).ReturnsAsync(newUser);

        var existingUser = await service.GetUserById(newUser.UserID);

        Assert.Equal(newUser.username, existingUser.username);
    }
}