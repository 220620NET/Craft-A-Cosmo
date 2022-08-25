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
        try{ 
            newUser.Username= newUser.Username!=""?newUser.Username:"";
            newUser.Email= newUser.Email!=""?newUser.Email:"";
            User findme= await _userRepo.GetUserByEmail(newUser.Email);
            User findMe= await _userRepo.GetUserByUsername(newUser.Username);
            if(newUser.Password==null||newUser.Email==null||newUser.Password==""||newUser.Email==""){
                throw new InvalidInputException();
            }else if (findme!=null){
                throw new EmailNotAvailableException();
            }else if (findMe!=null){
                throw new UsernameNotAvailableException();
            }else{
                return await _userRepo.CreateUser(newUser);
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
    
}
