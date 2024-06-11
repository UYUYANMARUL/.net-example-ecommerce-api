using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Basket
{
    public class UpdateBasketItemQuantityRequest
    {
       public Guid BasketItemId { get; set; }
       public int BasketItemQuantity { get; set; }
    }
}
