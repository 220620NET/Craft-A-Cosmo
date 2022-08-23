using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Zipcodes = new HashSet<Zipcode>();
        }

        public int CityId { get; set; }
        public int StateIdFk { get; set; }
        public string CityName { get; set; } = null!;

        public virtual State StateIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Zipcode> Zipcodes { get; set; }
    }
}
