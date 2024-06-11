using ETicaretAPI.Application.DTOs.Order.ListDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.SetPriceToOrder
{
    public class SetPriceToOrderCommandRequest : IRequest<SetPriceToOrderCommandResponse>
    {
        public Guid OrderId { get; set; }
        public List<SetPriceToOrderItemRequest> OrderItems { get; set; }

    }
}
