using DataAccess.Entities;

namespace DataAccess;

public interface IUserRepo
{
    public User GetUserByEmail(string email);
     public User GetUserByUsername(string username);
    public User GetUserByUserId(int userID);
    public User CreateUser(User newUser);
    public User UpdateUser(User newUser);
}
