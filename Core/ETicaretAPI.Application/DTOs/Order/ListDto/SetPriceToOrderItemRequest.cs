using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Order.ListDto
{
    public class SetPriceToOrderItemRequest
    {
        public Guid OrderItemId { get; set; }
        public float PiecePrice { get; set; }
    }
}
