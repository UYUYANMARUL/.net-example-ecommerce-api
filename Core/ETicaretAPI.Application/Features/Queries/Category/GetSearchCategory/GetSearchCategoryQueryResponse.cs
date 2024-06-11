using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory
{
    public class GetSearchCategoryQueryResponse
    {
        public int TotalCategoryCount { get; set; }
        public object Categories { get; set; }
    }
}
