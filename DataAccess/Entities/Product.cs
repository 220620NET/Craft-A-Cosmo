using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
        }

        public int ProductId { get; set; }
        public int CategoryIdFk { get; set; }
        public int ProductOptionsIdFk { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCol { get; set; }
        public string? ProductImage { get; set; }
        public byte? Listed { get; set; }

        public virtual Category CategoryIdFkNavigation { get; set; } = null!;
        public virtual ProductOption ProductOptionsIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
    }
}
