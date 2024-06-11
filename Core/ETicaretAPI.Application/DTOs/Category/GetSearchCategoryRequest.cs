using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public class GetSearchCategoryRequest
    {
        public string? SearchValue { get; set; } = "a";
        public int DataSize { get; set; } = 4;
    }
}
