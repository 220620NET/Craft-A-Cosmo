using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class SavedAddress
    {
        public int SavedAddressId { get; set; }
        public int UserIdFk { get; set; }
        public int BillingAddressIdFk { get; set; }

        public virtual Address BillingAddressIdFkNavigation { get; set; } = null!;
        public virtual User UserIdFkNavigation { get; set; } = null!;
    }
}
