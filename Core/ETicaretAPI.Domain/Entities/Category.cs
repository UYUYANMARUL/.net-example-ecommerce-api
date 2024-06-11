using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
   public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public Guid? topcategoryId { get; set; }
        public Category? topcategory { get; set; } 
        public ICollection<Product>? Products { get; set; }
        public ICollection<SpecName>? SpecNames { get; set; }
        public bool IsExsitSubCategory { get; set; }

    }
}
