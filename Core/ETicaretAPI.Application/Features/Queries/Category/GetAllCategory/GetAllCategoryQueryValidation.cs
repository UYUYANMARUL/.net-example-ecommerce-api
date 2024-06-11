using ETicaretAPI.Application.Features.Queries.Category.GetAllCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryValidation : AbstractValidator<GetAllCategoryQueryRequest>
    {
        public GetAllCategoryQueryValidation()
        {

        }
    }
}
