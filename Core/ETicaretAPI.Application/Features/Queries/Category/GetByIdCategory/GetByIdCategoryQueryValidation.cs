using ETicaretAPI.Application.Features.Queries.Category.GetByIdCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryValidation : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryQueryValidation()
        {

        }
    }
}
