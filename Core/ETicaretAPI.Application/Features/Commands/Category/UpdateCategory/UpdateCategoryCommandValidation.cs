using ETicaretAPI.Application.Features.Commands.Category.UpdateCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidation()
        {

        }
    }
}
