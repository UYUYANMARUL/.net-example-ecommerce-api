using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetAllSpecIdInListedProductsRequest
    {
        public Guid CategoryId { get; set; }
        public string SearchKey { get; set; }
    }
}
