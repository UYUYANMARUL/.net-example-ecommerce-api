using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Spec.GetSpecList
{
   public class GetSpecListQueryRequest :IRequest<GetSpecListQueryResponse>
    {
        public Guid? CategoryId { get; set; }
        public string? SearchKey { get; set; }
    }
}
