using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Specs.CreateSpec
{
    public class CreateSpecCommandRequest:IRequest<CreateSpecCommandResponse>
    {
        public string SpecDetailName { get; set; }
        public bool IsItnumber { get; set; }
        public string Description { get; set; }
    }
}
