using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
