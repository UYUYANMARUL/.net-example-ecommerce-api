using ETicaretAPI.Application.DTOs.Order.ListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Order
{
    public class SetPriceToOrderRequest
    {
        public Guid OrderId { get; set; }
        public List<SetPriceToOrderItemRequest> OrderItems { get; set; }

    }
}
