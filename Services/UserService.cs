using DataAccess.Entities;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo repo)
    {
        _userRepo = repo;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            return await _userRepo.GetUserByEmail(email);
        }
        catch (EmailNotAvailableException)
        {
            
            throw new EmailNotAvailableException();
        }
    }

    public async Task<User> GetUserByUsername(string username)
    {
        try
        {
            return await _userRepo.GetUserByUsername(username);
        }
        catch (UsernameNotAvailableException)
        {
            
            throw new UsernameNotAvailableException();
        }
    }

    public async Task<User> GetUserByUserId(int userId)
    {
        try
        {
            return await _userRepo.GetUserByUserId(userId);
        }
        catch (UserNotAvailableException)
        {
            
            throw new UserNotAvailableException();
        }
    }
     public async Task<User> CreateUser(User newUser)
    {
        try
        {
            return await _userRepo.CreateUser(newUser);
        }
        catch (UserNotAvailableException)
        {
            
            throw new UserNotAvailableException();
        }
    }
     
}