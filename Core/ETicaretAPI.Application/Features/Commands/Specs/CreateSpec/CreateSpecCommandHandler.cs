
using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Specs.CreateSpec
{
    class CreateSpecCommandHandler : IRequestHandler<CreateSpecCommandRequest, CreateSpecCommandResponse>
    {
        readonly ISpecService _specService;
        readonly IMapper _mapper;

        public CreateSpecCommandHandler(ISpecService specService, IMapper mapper)
        {
            _specService = specService;
            _mapper = mapper;
        }

        public async Task<CreateSpecCommandResponse> Handle(CreateSpecCommandRequest request, CancellationToken cancellationToken)
        {
           await _specService.CreateSpecAsync(_mapper.Map<CreateSpecRequest>(request));
            return new();
        }
    }
}
