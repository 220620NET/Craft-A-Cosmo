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
        public int ShippingAddressIdFk { get; set; }
        public int BillingAddressIdFk { get; set; }
        public int UserIdFk { get; set; }
        public DateTime? PurchaseTime { get; set; }
        public string? ShippingNote { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Address BillingAddressIdFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Address ShippingAddressIdFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserIdFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }
    }
}
