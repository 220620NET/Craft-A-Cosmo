using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class User{
    public User(int UserId, string? Username, string Password, string Email, string Role){
        this.UserId = UserId;

        this.Username = Username;
        
        this.Password = Password;
        
        this.Email = Email;
        
        this.Role = Role;
    }
}