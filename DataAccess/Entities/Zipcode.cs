using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Zipcode
    {
        public Zipcode()
        {
            Addresses = new HashSet<Address>();
        }

        public int ZipcodeId { get; set; }
        public int CityIdFk { get; set; }
        public int ZipCode1 { get; set; }

        public virtual City CityIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
