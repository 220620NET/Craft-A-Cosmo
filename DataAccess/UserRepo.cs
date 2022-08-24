using CustomExceptions;
using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class UserRepo : IUserRepo
{

    private readonly  p3dbContext _context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public UserRepo(p3dbContext context)
    {
        _context = context;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            User? user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
            if (user == null) 
            { 
                throw new EmailNotAvailableException(); 
            }
            return user!;           
        }
        catch (NullReferenceException)
        {
            throw new EmailNotAvailableException();
        }
        catch (EmailNotAvailableException)
        {
            throw new EmailNotAvailableException();
        }
    }
    /// <summary>
    /// Will get a specfic user and will allow for registration
    /// </summary>
    /// <param name="username">A valid username</param>
    /// <returns>The requested user</returns>
    /// <exception cref="NotImplementedException">There is no user with that username</exception>
    public async Task<User> GetUserByUsername(string username)
    {
        try
        {
            User? found = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Username == username);
            if (found == null)
            {
                throw new UsernameNotAvailableException();
            }
            return  found;
           
        } 
        catch (NullReferenceException)
        {
            throw new UsernameNotAvailableException();
        }
        catch (UsernameNotAvailableException)
        {
            throw new UsernameNotAvailableException();
        }

    }
    /// <summary>
    /// Will get a specific user
    /// </summary>
    /// <param name="userID">The user in question</param>
    /// <returns>The requested user</returns>
    /// <exception cref="UsernameNotAvailableException">There is no user with that ID</exception>
    public async Task<User> GetUserByUserId(int userID)
    {
        try
        {
            User? foundUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.UserId == userID);
            if(foundUser != null) return foundUser;
            throw new UserNotAvailableException();
        }
        catch (NullReferenceException)
        {
            throw new UsernameNotAvailableException();
        }
        catch (UserNotAvailableException)
        {
            throw new UserNotAvailableException();
        }
    }
    /// <summary>
    /// Will add a user to the database
    /// </summary>
    /// <param name="newUser">A valid user</param>
    /// <returns>The new user</returns>
    public async Task<User> CreateUser(User newUser)
    {
        _context.Users.Add(newUser);
        Finish();
        return newUser;
    }

    public async Task<User> UpdateUser(User newUser)
        {
            try
            {
                User? p = await _context.Users.FirstOrDefaultAsync(t => t.UserId == newUser.UserId);                
                Finish();
                return p ?? throw new UserNotAvailableException();

            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
        }
    protected void Finish()
    {
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
