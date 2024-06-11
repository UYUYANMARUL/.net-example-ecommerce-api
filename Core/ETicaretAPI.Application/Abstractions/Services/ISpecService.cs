using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
   public interface ISpecService
    {
       Task CreateSpecAsync(CreateSpecRequest createSpecRequest);
       Task DeleteSpecAsync(DeleteSpecRequest deleteSpecRequest);
       Task<GetAllSpecResponse> GetAllSpecAsync();

        Task<GetSpecListResponse> GetSpecListAsync(GetSpecListRequest request);
    }
}
