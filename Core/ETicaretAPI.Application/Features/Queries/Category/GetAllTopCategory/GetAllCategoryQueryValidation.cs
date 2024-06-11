using ETicaretAPI.Application.Features.Queries.Category.GetAllTopCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Queries.Category.GetAllTopCategory
{
    public class GetAllTopCategoryQueryValidation : AbstractValidator<GetAllTopCategoryQueryRequest>
    {
        public GetAllTopCategoryQueryValidation()
        {

        }
    }
}
