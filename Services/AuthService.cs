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

    public async Task<User> LoginWithUsername(string? username, string? password)
    {
        try
        {
            User found = await _userRepo.GetUserByUsername(username!);
            return found.Password==password?found:throw new InvalidCredentialsException(); 
        }

        catch (NullReferenceException)
        {
            throw new UsernameNotAvailableException();
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
    public async Task<User> LoginWithEmail(string? email, string? password)
    {
        try
        {
            User found = await _userRepo.GetUserByEmail(email!);
            return found.Password==password?found:throw new InvalidCredentialsException(); 
        }
        catch (EmailNotAvailableException)
        {
            throw new EmailNotAvailableException();
        }
        catch (InvalidCredentialsException)
        {
            throw new InvalidCredentialsException();
        }

        catch (NullReferenceException)
        {
            throw new EmailNotAvailableException();
        }
    }
    public async Task<User> Register(User newUser)
    {  
        try
        {
            bool email = true;
            bool name = true;
            if (String.IsNullOrWhiteSpace(newUser.Password) || String.IsNullOrWhiteSpace(newUser.Email))
            {
                throw new  InvalidInputException();
            } 
            try
            {
                User foundEmail = await _userRepo.GetUserByEmail(newUser.Email);
            }
            catch (NullReferenceException)
            {
                email= false;
            }
            finally
            {
                try
                { 
                    User foundUser = await _userRepo.GetUserByUsername(newUser.Username);
                }
                catch (NullReferenceException)
                {
                    name = false;
                }
            }
            if(!name && !email)
            {
                return await _userRepo.CreateUser(newUser);
            }
            if (name)
            {
                throw new UsernameNotAvailableException();
            }
            else
            {
                throw new EmailNotAvailableException();
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
        catch (InvalidInputException)
        {
            throw new InvalidInputException();
        }

        catch (NullReferenceException)
        {            
            return await _userRepo.CreateUser(newUser);
        }

    }
    public async Task<User> UpdateUser(User newUser)
    {
        try
        {
            User foundUser = await _userRepo.GetUserByUserId(newUser.UserId);
            if (String.IsNullOrWhiteSpace(foundUser.Email))
            {
                throw new UserNotAvailableException(); 
            }
            else { return await _userRepo.UpdateUser(newUser); }
        }
        catch (UserNotAvailableException)
        {
            throw new UserNotAvailableException();
        }
        catch (NullReferenceException)
        {
            throw new UserNotAvailableException();
        }

    }
}
