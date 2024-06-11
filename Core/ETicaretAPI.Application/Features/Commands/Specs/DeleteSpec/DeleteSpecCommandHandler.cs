using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Specs.DeleteSpec
{
    public class DeleteSpecCommandHandler : IRequestHandler<DeleteSpecCommandRequest, DeleteSpecCommandResponse>
    {

        readonly ISpecService _specService;
        readonly IMapper _mapper;

        public DeleteSpecCommandHandler(ISpecService specService, IMapper mapper)
        {
            _specService = specService;
            _mapper = mapper;
        }
        public async Task<DeleteSpecCommandResponse> Handle(DeleteSpecCommandRequest request, CancellationToken cancellationToken)
        {
            await _specService.DeleteSpecAsync(_mapper.Map<DeleteSpecRequest>(request));
            return new();
        }
    }
}
