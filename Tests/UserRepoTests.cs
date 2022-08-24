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
        //var mockdb = new Mock<p3dbContext>();
          var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",

        };
        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserByEmail(newUser.Email)).ReturnsAsync(newUser);

       // UserRepo repo = new UserRepo(mockdb.Object);
         UserService service = new UserService(mockUser.Object);

        //var existingUser = await repo.GetUserByEmail(newUser.Email);
        var existingUser = await service.GetUserByEmail(newUser.Email);

        Assert.Equal(newUser.Email, existingUser.Email);
    }

    [Fact]
    public async Task GetUserByUserId()
    {
        //var mockUser = new Mock<p3dbContext>();
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",
        };
         
         mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.GetUserByUserId(newUser.UserId)).ReturnsAsync(newUser);
       // UserRepo repo = new UserRepo(mockUser.Object);
        UserService service = new UserService(mockUser.Object);

    
         var existingUser = await service.GetUserByUserId(newUser.UserId);

        Assert.Equal(newUser.UserId, existingUser.UserId);
    }

    [Fact]
    public  async Task GetUserByUsername()
    {
       // var mockUser = new Mock<p3dbContext>();
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
     [Fact]
    public async Task CreateUser()
    {
        //var mockUser = new Mock<p3dbContext>();
         var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",

        };
         mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);

        var existingUser = await service.CreateUser(newUser);

        Assert.Equal(newUser, existingUser);
    }

    [Fact]
    public async Task UpdateUser()
    {
       // var mockUser = new Mock<p3dbContext>();
        var mockUser = new Mock<IUserRepo>();
    
        User newUser = new User{
            UserId = 2,
            Email = "merp@merp.com",
            Username = "merple",
        };
         mockUser.Setup(repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
         mockUser.Setup(repo => repo.UpdateUser(newUser)).ReturnsAsync(newUser);

        UserService service = new UserService(mockUser.Object);

        var existingUser = await service.UpdateUser(newUser);

        Assert.Equal(newUser, existingUser);
    }
}