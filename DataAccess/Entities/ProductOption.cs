using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ProductOption
    {
        public ProductOption()
        {
            Products = new HashSet<Product>();
        }

        public int ProductOptionsId { get; set; }
        public string? ColorVariant { get; set; }
        public string? SizeVariant { get; set; }
        public string? SoundVariant { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
