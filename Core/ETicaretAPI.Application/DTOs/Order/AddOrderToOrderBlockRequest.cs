using ETicaretAPI.Application.DTOs.Order.ListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Order
{
    public class AddOrderToOrderBlockRequest
    {
       public Guid OrderBlockId { get; set; }
    }
}
