using Moq;
using DataAccess.Entities;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;


namespace Tests;

public class UserRepoTests
{

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

        UserRepo repo = new UserRepo(mockUser.Object);

        var existingUser = await repo.GetUserByEmail(newUser.Email);

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

        UserRepo repo = new UserRepo(mockUser.Object);

        var existingUser = await repo.GetUserById(newUser.UserID);

        Assert.Equal(newUser.UserID, existingUser.UserID);
    }

    [Fact]
    public void GetUserByUsername()
    {
        var mockUser = new Mock<IUserRepo>();

        User newUser = new User{
            UserID = 2,
            Email = "merp@merp.com",
            username = "merple",
        };
        
        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserById(newUser.UserID)).ReturnsAsync(newUser);

        var existingUser = await repo.GetUserById(newUser.UserID);

        Assert.Equal(newUser.username, existingUser.username);
    }
     [Fact]
    public async Task CreateUser()
    {
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",

        };

        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.CreateUser(newUser.User)).ReturnsAsync(newUser);

        UserRepo repo = new UserRepo(mockUser.Object);

        var existingUser = await repo.CreateUser(newUser.User);

        Assert.Equal(newUser.User, existingUser.User);
    }

    [Fact]
    public async Task UpdateUser()
    {
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserID = 2,
            Email = "merp@merp.com",
            username = "merple",
        };

        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.UpdateUser(newUser.User)).ReturnsAsync(newUser);

        UserRepo repo = new UserRepo(mockUser.Object);

        var existingUser = await repo.UpdateUser(newUser.User);

        Assert.Equal(newUser.User, existingUser.User);
    }
}