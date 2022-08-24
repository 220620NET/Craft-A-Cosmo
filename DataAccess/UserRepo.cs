using CustomExceptions;
using DataAccess.Entities;

namespace DataAccess;
public class UserRepo : IUserRepo
{

    private readonly  P3DbContext _context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public UserRepo(P3DbContext context)

 
    {
        _context = context;
    }
     public User GetUserByEmail(string email)
    {
        try
        {
             return _context.User.AsNoTracking().FirstOrDefault(user => user.email == email)!;
           
        }
        catch (UserNotFoundException)
        {
            throw new InvalidECredentialsException();
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
    public User GetUserByusername(string username)
    {
        try
        {
             return _context.Users.AsNoTracking().FirstOrDefault(user => user.username == username)!;
           
        }
        catch (UserNotFoundException)
        {
            throw new InvalidInputException();
        }
        catch (UserNameNotAvailableException)
        {
            throw new UserNameNotAvailableException();
        }
        
    }
    /// <summary>
    /// Will get a specific user
    /// </summary>
    /// <param name="userID">The user in question</param>
    /// <returns>The requested user</returns>
    /// <exception cref="UsernameNotAvailableException">There is no user with that ID</exception>
    public User GetUserByUserId(int userID)
    {
        User? foundUser = _context.Users.AsNoTracking().FirstOrDefault(user => user.userID == userID);
        if(foundUser != null) return foundUser;
        throw new UsernameNotAvailableException();
    }
    /// <summary>
    /// Will add a user to the database
    /// </summary>
    /// <param name="newUser">A valid user</param>
    /// <returns>The new user</returns>
    public User CreateUser(User newUser)
    {
        _context.User.Add(newUser);
        Finish();
        return newUser;
    }

    public User UpdateUser(User newUser)
        {
            try
            {
                User? p = _dbContext.User.FirstOrDefault(t => t.userID == User.userID);                
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
