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
        public DateTime? PurchaseTime { get; set; } //if null means not purchased
        public string? ShippingNote { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Address BillingAddressFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Address ShippingAddressFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserIdFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }
    }
}
