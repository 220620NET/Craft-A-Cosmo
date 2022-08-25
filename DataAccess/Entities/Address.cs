using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Address
    {
        public Address()
        {
            CartBillingAddressIdFkNavigations = new HashSet<Cart>();
            CartShippingAddressIdFkNavigations = new HashSet<Cart>();
            SavedAddresses = new HashSet<SavedAddress>();
        }

        public int AddressId { get; set; }
        public int? UserIdFk { get; set; }
        public string? StreetAddy { get; set; }
        public int? ApartmentNum { get; set; }
        public int ZipcodeFk { get; set; }
        public int CityFk { get; set; }
        public int StateFk { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual City CityFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual State StateFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? UserIdFkNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Zipcode ZipcodeFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Cart> CartBillingAddressIdFkNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Cart> CartShippingAddressIdFkNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<SavedAddress> SavedAddresses { get; set; }
    }
}
