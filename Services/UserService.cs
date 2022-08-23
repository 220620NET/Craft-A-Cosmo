using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserService
{
    private readonly IUserDao _userRepo;

    public UserService(IUserDao repo)
    {
        _userRepo = repo;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            return await _userRepo.GetUserByEmail();
        }
        catch (EmailNotAvailableException)
        {
            
            throw new EmailNotAvailableException;
        }
    }

    public async Task<User> GetUserByUsername(string username)
    {
        try
        {
            return await _userRepo.GetUserByUsername();
        }
        catch (UsernameNotAvailableException)
        {
            
            throw new UsernameNotAvailableException;
        }
    }

    public async Task<User> GetUserById(int userId)
    {
        try
        {
            return await _userRepo.GetUserById();
        }
        catch (UserNotAvaliableException)
        {
            
            throw new UserNotAvaliableException;
        }
    }
}