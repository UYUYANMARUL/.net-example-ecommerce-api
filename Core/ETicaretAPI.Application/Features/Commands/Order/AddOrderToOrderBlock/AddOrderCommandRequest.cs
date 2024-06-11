using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.AddOrderToOrderBlock
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
