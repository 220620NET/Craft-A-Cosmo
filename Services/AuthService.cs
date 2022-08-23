using DataAccess;
using DataAccess.Entities;
using CustomExceptions;
namespace Services;
public class AuthService
{
    private readonly IUserRepo _userRepo;
    
    public AuthService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public User LoginWithUsername(string? username, string? password)
    {
        try
        {
            User found = _userRepo.GetUserByUsername(username);
            return found.Password==password?found:throw new InvalidCredentialsException(); 
        }
        catch (UsernameNotAvailableException)
        {
            throw new UsernameNotAvailableException();
        }
        catch (InvalidCredentialsException)
        {
            throw new InvalidCredentialsException();
        }
    }
    public User LoginWithEmail(string? email, string? password)
    {

    }
    public User Register(User newUser)
    {

    }
    public User UpdateUser(User newUser)
    {

    }
}
