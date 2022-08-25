using DataAccess.Entities;

namespace DataAccess;

public interface IUserRepo
{
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByUsername(string username);
    Task<User> GetUserByUserId(int userID);
    Task<User> CreateUser(User newUser);
     
}
