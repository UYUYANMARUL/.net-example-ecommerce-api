﻿using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }

}
