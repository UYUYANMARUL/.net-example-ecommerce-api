using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public class GetSearchCategoryResponse
    {
        public int TotalCategoryCount { get; set; }
        public object Categories { get; set; }
    }
}
