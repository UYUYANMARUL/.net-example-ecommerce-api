using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public  class CategoryReadDto
    {
        public string CategoryName { get; set; }
        public Guid? topcategoryId { get; set; }
        public Category? topcategory { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<SpecName>? SpecName { get; set; }
        public bool IsExsitSubCategory { get; set; }
    }
}
