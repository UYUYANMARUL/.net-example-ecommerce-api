using ETicaretAPI.Application.Features.Commands.Category.RemoveCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Commands.Category.RemoveCategory
{
    public class RemoveCategoryCommandValidation : AbstractValidator<RemoveCategoryCommandRequest>
    {
        public RemoveCategoryCommandValidation()
        {

        }
    }
}
