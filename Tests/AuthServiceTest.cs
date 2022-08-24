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
        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).ReturnsAsync(userToReturn);

        AuthService auth = new(mockedRepo.Object);

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
        mockedRepo.Setup(r => r.GetUserByEmail(userToReturn.Email)).ReturnsAsync(userToReturn);
        AuthService auth = new(mockedRepo.Object);
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

        mockedRepo.Setup(r => r.GetUserByUsername(userToReturn.Username)).ReturnsAsync(userToReturn);

        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<InvalidCredentialsException>(() => auth.LoginWithUsername("test", "wrongPassword"));
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
        mockedRepo.Setup(r => r.GetUserByEmail(userToReturn.Email)).ReturnsAsync(userToReturn);

        AuthService auth = new(mockedRepo.Object);
        
        await Assert.ThrowsAsync<InvalidCredentialsException>(() => auth.LoginWithEmail("test@test.com", "wrongPassword"));
    }
    /*
     *      Login Successes
     */
    [Fact]
    public async Task LoginWithEmailSucceedsWithValidInformation()
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
        mockedRepo.Setup(r => r.GetUserByEmail(newUser.Email)).ReturnsAsync(newUser);

        AuthService auth = new(mockedRepo.Object);

        User foundUser = await auth.LoginWithEmail(newUser.Email,newUser.Password);

         

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
        mockedRepo.Setup(r => r.GetUserByUsername(newUser.Username)).ReturnsAsync(newUser);

        AuthService auth = new(mockedRepo.Object);

        User foundUser = await auth.LoginWithUsername(newUser.Username,newUser.Password);

        

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
            Username = "test2",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.GetUserByUsername(userToAdd.Username)).ReturnsAsync(userToAdd);
        mockedRepo.Setup(r => r.GetUserByEmail(userToAdd.Email)).ReturnsAsync(userToAdd);

        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<UsernameNotAvailableException>(() => auth.Register(userToTest));
    }
    [Fact]
    // public async Task RegisterFailsWithInvalidEmail()
    // {
    //     var mockedRepo = new Mock<IUserRepo>();

    //     User userToAdd = new()
    //     {
    //         UserId = 1,
    //         Username = "test",
    //         Password = "test",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     User userToTest = new()
    //     {
    //         UserId = 1,
    //         Username = "test",
    //         Password = "test",
    //         Email = "test2@test.com",
    //         Role = "User"
    //     };

    //     mockedRepo.Setup(r => r.GetUserByUsername(userToAdd.Username)).ReturnsAsync(userToAdd);
    //     mockedRepo.Setup(r => r.GetUserByEmail(userToAdd.Email)).ReturnsAsync(userToAdd);

    //     AuthService auth = new(mockedRepo.Object);

    //     await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.Register(userToTest));
    // }
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

        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<InvalidInputException>(() => auth.Register(userToTest));
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

        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<InvalidInputException>(() => auth.Register(userToTest));
    }
    /*
     *      Register Succeeds
     */
    [Fact]
    // public async Task RegisterSucceedsWithValidInformation()
    // {
    //     var mockedRepo = new Mock<IUserRepo>();

    //     User userToTest = new()
    //     {
    //         UserId = 1,
    //         Username = "test",
    //         Password = "test",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     AuthService auth = new(mockedRepo.Object);

    //     User newUser = await  auth.Register(userToTest);

    //     mockedRepo.Verify(r => r.GetUserByUserId(userToTest.UserId), Times.Once()); 

    //     Assert.NotNull(newUser);
    //     Assert.Equal(newUser.Username, userToTest.Username);
    //     Assert.Equal(newUser.Password, userToTest.Password);
    // }
    /*
     *      Update Fails
     */
    [Fact]
    public async Task UpdateFailsWithInvalidUserID()
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
            UserId = 2,
            Username = "test2",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.GetUserByUserId(userToAdd.UserId)).ReturnsAsync(userToAdd);
        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<UserNotAvailableException>(() => auth.UpdateUser(userToTest));
    }
    /*
     *      Update Succeeds
     */
    [Fact]
    // public async Task UpdateSucceedsWithVaildInformation()
    // {
    //     var mockedRepo = new Mock<IUserRepo>();

    //     User userToAdd = new()
    //     {
    //         UserId = 1,
    //         Username = "test",
    //         Password = "test",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     User userToTest = new()
    //     {
    //         UserId = 1,
    //         Username = "test2",
    //         Password = "test2",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     mockedRepo.Setup(r => r.GetUserByUserId(userToAdd.UserId)).ReturnsAsync(userToAdd);

    //     AuthService auth = new(mockedRepo.Object);

    //     User updatedUser = await auth.UpdateUser(userToTest);

    //     mockedRepo.Verify(r => r.GetUserByUserId(userToTest.UserId), Times.Once());

    //     Assert.NotNull(updatedUser);
    //     Assert.Equal(updatedUser.Username, userToTest.Username);
    //     Assert.Equal(updatedUser.Password, userToTest.Password);
    //     Assert.Equal(userToTest,updatedUser);
    // }
}
