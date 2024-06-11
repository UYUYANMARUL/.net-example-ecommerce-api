using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Queries.Spec.GetAllSpec;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
   public class SpecService :ISpecService
    {
        readonly IMapper _mapper;
        readonly ISpecWriteRepository _specWriteRepository;
        readonly ISpecReadRepository _specReadRepository;
        readonly IProductService _productService;

        public SpecService(IMapper mapper, ISpecWriteRepository specWriteRepository, ISpecReadRepository specReadRepository, IProductService productService)
        {
            _mapper = mapper;
            _specWriteRepository = specWriteRepository;
            _specReadRepository = specReadRepository;
            _productService = productService;
        }

        public async Task CreateSpecAsync(CreateSpecRequest createSpecRequest)
        {
            await _specWriteRepository.AddAsync(_mapper.Map<SpecName>(createSpecRequest));
            await _specWriteRepository.SaveAsync();
         }

        public async Task DeleteSpecAsync(DeleteSpecRequest deleteSpecRequest)
        {
            await _specWriteRepository.RemoveAsync(deleteSpecRequest.Id);
            await _specWriteRepository.SaveAsync();
        }

        public async Task<GetAllSpecResponse> GetAllSpecAsync()
        {

            List<SpecName> Spec = _specReadRepository.GetAll(false).OrderByDescending(p=>p.CreatedDate).ToList();
            return new() { Spec = Spec};
        }

        public async Task<GetSpecListResponse> GetSpecListAsync(GetSpecListRequest request) 
        {
            if (request.CategoryId == null) request.CategoryId = Guid.Empty;
            if (request.SearchKey == null)
                request.SearchKey = "";
            HashSet<Guid> UniqueId = new HashSet<Guid>();
            HashSet<Guid> data = await _productService.GetAllSpecIdInListedProductsAsync(new() { CategoryId =request.CategoryId, SearchKey = request.SearchKey});
            var x = await _specReadRepository.GetAll().ToListAsync();
            ICollection<SpecName> specs = await _specReadRepository.GetWhere(p => data.Contains(p.Id)).ToListAsync();
            return new()
            {
                specs = specs
            };
        }

    }
}
