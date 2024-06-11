using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class ProductSpec :BaseEntity
    {
        public Guid SpecNameId { get; set; }
        public SpecName SpecName { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Value { get; set; }
      
      


    }
}
