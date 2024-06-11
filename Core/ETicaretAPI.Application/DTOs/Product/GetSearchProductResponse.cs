using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetSearchProductResponse
    {

        public int TotalProductCount { get; set; }
        public object Products { get; set; }
    }
}
