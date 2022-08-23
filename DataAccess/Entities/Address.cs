using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Address
    {
        public Address()
        {
            CartBillingAddressFkNavigations = new HashSet<Cart>();
            CartShippingAddressFkNavigations = new HashSet<Cart>();
        }

        public int AddressId { get; set; }
        public int? UserIdFk { get; set; }
        public string? StreetAddy { get; set; }
        public int? ApartmentNum { get; set; }
        public int ZipcodeFk { get; set; }
        public int CityFk { get; set; }
        public int StateFk { get; set; }

        public virtual City CityFkNavigation { get; set; } = null!;
        public virtual State StateFkNavigation { get; set; } = null!;
        public virtual User? UserIdFkNavigation { get; set; }
        public virtual Zipcode ZipcodeFkNavigation { get; set; } = null!;
        public virtual ICollection<Cart> CartBillingAddressFkNavigations { get; set; }
        public virtual ICollection<Cart> CartShippingAddressFkNavigations { get; set; }
    }
}
