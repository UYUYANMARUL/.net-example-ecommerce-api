using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public class CreateCategoryRequest
    {
        public List<Guid>? SpecNameId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public Guid topcategoryId { get; set; }
    }
}
