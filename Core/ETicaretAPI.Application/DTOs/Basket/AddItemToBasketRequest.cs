﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Basket
{
  public  class AddItemToBasketRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
