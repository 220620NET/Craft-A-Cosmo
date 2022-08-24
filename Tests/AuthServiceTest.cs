using DataAccess.Entities;
using DataAccess;
using Services;
using CustomExceptions;
using Moq;
using Xunit;
using System.Threading.Tasks;
namespace Tests;
public class AuthServiceTest
{
    /*
     *      Login Failures
     */
    [Fact]
    public async Task LoginFailsWithInvalidUsername()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToReturn = new()
        {
            UserId = 1,
            Username="test",
            Password="test",
            Email="test@test.com",
            Role="User"            
        };
        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).Returns(userToReturn);

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<UsernameNotAvailableException>(() => auth.LoginWithUsername("wrongUsername", "test"));
    }
    [Fact]
    public async Task LoginFailsWithInvalidEmail()
    {
        var mockedRepo = new Mock<IUserRepo>();
        User userToReturn = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).Returns(userToReturn);
        AuthService auth = new(mockedRepo);
        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.LoginWithEmail("wrongEmail", "test"));
    }
    [Fact]
    public async Task LoginWithUsernameFailsWithInvalidPassword()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToReturn = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).Returns(userToReturn);

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.LoginWithUsername("test", "wrongPassword"));
    }
    [Fact]
    public async Task LoginWithEmailFailsWithInvalidPassword()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToReturn = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).Returns(userToReturn);

        AuthService auth = new(mockedRepo);
        
        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.LoginWithEmail("test@test.com", "wrongPassword"));
    }
    /*
     *      Login Successes
     */
    [Fact]
    public async void LoginWithEmailSucceedsWithValidInformation()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User newUser = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.CreateUser(newUser)).Returns(newUser);

        AuthService auth = new(mockedRepo);

        User foundUser = await auth.LoginWithEmail(newUser.Email,newUser.Password);

        mockedRepo.Verify(r => r.LoginWithEmail(newUser.Email,newUser.Password), Times.Once()); 

        Assert.NotNull(foundUser);
        Assert.Equal(foundUser.Email, newUser.Email);
        Assert.Equal(foundUser.Password, newUser.Password);

    }
    [Fact]
    public async Task LoginWithUsernameSucceedsWithValidInformation()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User newUser = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.CreateUser(newUser)).Returns(newUser);

        AuthService auth = new(mockedRepo);

        User foundUser = await auth.LoginWithUsername(newUser.Username,newUser.Password);

        mockedRepo.Verify(r => r.LoginWithUsername(newUser.Username,newUser.Password), Times.Once()); 

        Assert.NotNull(foundUser);
        Assert.Equal(foundUser.Username, newUser.Username);
        Assert.Equal(foundUser.Password, newUser.Password);
    }

    /*
     *      Register
     */
    [Fact]
    public async Task RegisterFailsWithInvalidUsername()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToAdd = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        User userToTest = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test2@test.com",
            Role = "User"
        };

        mockedRepo.Setup(r => r.CreateUser(userToAdd)).Returns(userToAdd);

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<UsernameNotAvailableException>(() => auth.Register(userToTest));
    }
    [Fact]
    public async Task RegisterFailsWithInvalidEmail()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToAdd = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        User userToTest = new()
        {
            UserId = 1,
            Username = "test2",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        mockedRepo.Setup(r => r.CreateUser(userToAdd)).Returns(userToAdd);

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.Register(userToTest));
    }
    [Fact]
    public async Task RegisterFailsWithMissingEmail() 
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToTest = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "",
            Role = "User"
        };

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<InputInvalidException>(() => auth.Register(userToTest));
    }
    [Fact]
    public async Task RegisterFailsWithMissingPassword()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToTest = new()
        {
            UserId = 1,
            Username = "test",
            Password = "",
            Email = "test@test.com",
            Role = "User"
        };

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<InputInvalidException>(() => auth.Register(userToTest));
    }
    /*
     *      Register Succeeds
     */
    [Fact]
    public async Task RegisterSucceedsWithValidInformation()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToTest = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        AuthService auth = new(mockedRepo);

        User newUser = await  auth.Register(userToTest);

        mockedRepo.Verify(r => r.Register(userToTest), Times.Once()); 

        Assert.NotNull(newUser);
        Assert.Equal(newUser.Username, userToTest.Username);
        Assert.Equal(newUser.Password, userToTest.Password);
    }
    /*
     *      Update Fails
     */
    [Fact]
    public void UpdateFailsWithInvalidUserID()
    {
        var mockedRepo = new Mock<IUserRepo>();

        User userToAdd = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        User userToTest = new()
        {
            UserId = 1,
            Username = "test2",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };

        mockedRepo.Setup(r => r.CreateUser(userToAdd)).Returns(userToAdd);

        AuthService auth = new(mockedRepo);

        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.Register(userToTest));
    }
    /*
     *      Update Succeeds
     */
    [Fact]
    public void UpdateSucceedsWithVaildInformation()
    {

    }
}
