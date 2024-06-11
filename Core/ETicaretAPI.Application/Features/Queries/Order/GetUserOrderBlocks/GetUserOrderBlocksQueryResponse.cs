using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetUserOrderBlocks
{
   public class GetUserOrderBlocksQueryResponse
    {
        public int TotalOrderBlocksCount { get; set; }
        public object OrderBlocks { get; set; }
    }
}
