using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Specs.CreateSpec
{
    class CreateSpecCommandValidation:AbstractValidator<CreateSpecCommandRequest>
    {
        public CreateSpecCommandValidation()
        {

        }
    }
}
