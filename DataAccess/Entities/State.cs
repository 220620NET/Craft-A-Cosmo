using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
