using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            Items = new HashSet<Item>();
        }

        public int CartId { get; set; }
        public int ShippingAddressFk { get; set; }
        public int BillingAddressFk { get; set; }
        public int UserIdFk { get; set; }
        public DateTime? PurchaseTime { get; set; }
        public string? ShippingNote { get; set; }

        public virtual Address BillingAddressFkNavigation { get; set; } = null!;
        public virtual Address ShippingAddressFkNavigation { get; set; } = null!;
        public virtual User UserIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
    }
}
