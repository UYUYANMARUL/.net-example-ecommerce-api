using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Order
{
    public class CreateOrderRequest
    {
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
