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
        try
        {
            User found = _userRepo.GetUserByEmail(email);
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
    public User Register(User newUser)
    {  
        try
        {
            User foundEmail = _userRepo.GetUserByEmail(newUser.Email);
            User foundUsername = _userRepo.GetUserByUsername(newUser.Email);
            if (newUser.Password==null || newUser.Email==null)
            {
                throw new InputInvalidException();
            }
            else if(String.IsNullOrWhiteSpace(foundEmail.Email))
            {
                throw new EmailNotAvailableException();
            }
            else if(String.IsNullOrWhiteSpace(foundUsername.Username))
            {
                throw new EmailNotAvailableException();
            }
            else
            {
                return _userRepo.CreateUser(newUser);
            }
            }
        catch (EmailNotAvailableException)
        {
            throw new EmailNotAvailableException();
        }
        catch (UsernameNotAvailableException)
        {
            throw new UsernameNotAvailableException();
        }
        catch (InputInvalidException)
        {
            throw new InputInvalidException();
        }

    }
    public User UpdateUser(User newUser)
    {
        try
        {
            User foundUser = _userRepo.GetUserByUserId(newUser.UserId);
            if (String.IsNullOrWhiteSpace(foundUser.Email))
            {
                return _userRepo.UpdateUser(newUser);
            }
            else { throw new UserNotAvailableException(); }
        }
        catch (UserNotAvailableException)
        {
            throw new UserNotAvailableException();
        }
    }
}
