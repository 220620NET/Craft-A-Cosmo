using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
