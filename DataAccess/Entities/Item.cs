using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public int ProductIdFk { get; set; }
        public int CartFk { get; set; }
        public int Quantity { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Cart CartFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product ProductIdFkNavigation { get; set; } = null!;
    }
}
