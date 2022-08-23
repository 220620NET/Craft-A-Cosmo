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
        await Assert.ThrowsAsync<UsernameNotAvailableException>(() => auth.LoginWithUsername("a", "test"));
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
        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.LoginWithEmail("a", "test"));
    }
    [Fact]
    public async Task LoginWithUsernameFailsWithInvalidPassword()
    {

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
        await Assert.ThrowsAsync<EmailNotAvailableException>(() => auth.LoginWithEmail("test@test.com", "s"));
    }
    /*
     *      Login Successes
     */
    [Fact]
    public void LoginWithEmailSucceedsWithValidInformation()
    {

    }
    [Fact]
    public void LoginWithUsernameSucceedsWithValidInformation()
    {

    }

    /*
     *      Register
     */
    [Fact]
    public void RegisterFailsWithInvalidUsername()
    {

    }
    [Fact]
    public void RegisterFailsWithInvalidEmail()
    {

    }
    [Fact]
    public void RegisterFailsWithMissingEmail() 
    {

    }
    [Fact]
    public void RegisterFailsWithMissingPassword()
    {

    }
    /*
     *      Register Succeeds
     */
    [Fact]
    public void RegisterSucceedsWithValidInformation()
    {

    }
    /*
     *      Update Fails
     */
    [Fact]
    public void UpdateFailsWithInvalidUserID()
    {

    }
    /*
     *      Update Succeeds
     */
    [Fact]
    public void UpdateSucceedsWithVaildInformation()
    {

    }
}
