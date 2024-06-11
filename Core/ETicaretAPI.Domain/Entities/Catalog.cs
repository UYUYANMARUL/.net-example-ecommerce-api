using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Catalog : BaseEntity
    {
        public string CatalogName { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public Guid CatalogId { get; set; }
        
    }
}
    