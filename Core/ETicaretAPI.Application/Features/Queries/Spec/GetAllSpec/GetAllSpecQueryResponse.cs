using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Spec.GetAllSpec
{
    public class GetAllSpecQueryResponse
    {
      public List<SpecName> Spec { get; set; }
    }
}
