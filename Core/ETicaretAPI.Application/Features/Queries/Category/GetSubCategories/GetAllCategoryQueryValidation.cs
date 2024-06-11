using ETicaretAPI.Application.Features.Queries.Category.GetSubCategories;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Queries.Category.GetSubCategories
{
    public class GetSubCategoriesQueryValidation : AbstractValidator<GetSubCategoriesQueryRequest>
    {
        public GetSubCategoriesQueryValidation()
        {

        }
    }
}
