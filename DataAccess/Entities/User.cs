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
            SavedAddresses = new HashSet<SavedAddress>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Cart> Carts { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<SavedAddress> SavedAddresses { get; set; }
    }
}
