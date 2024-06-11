using ETicaretAPI.Application.Features.Commands.Category.CreateCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidation()
        {

        }
    }
}
