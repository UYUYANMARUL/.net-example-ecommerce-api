using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Spec.GetSpecList
{
    public class GetSpecListQueryResponse
    {
        public ICollection<SpecName> specs { get; set; }
    }
}
