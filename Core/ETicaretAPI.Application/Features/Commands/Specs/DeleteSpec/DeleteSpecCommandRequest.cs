using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Specs.DeleteSpec
{
    public class DeleteSpecCommandRequest: IRequest<DeleteSpecCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
