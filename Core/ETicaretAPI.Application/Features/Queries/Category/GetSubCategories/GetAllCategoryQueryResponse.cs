using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X = ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Features.Queries.Category.GetSubCategories
{
   public class GetSubCategoriesQueryResponse
    {
         public List<X.Category> Category { get; set; }

    }
}
