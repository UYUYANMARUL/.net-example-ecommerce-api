using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid topcategoryId { get; set; }
    }
}
