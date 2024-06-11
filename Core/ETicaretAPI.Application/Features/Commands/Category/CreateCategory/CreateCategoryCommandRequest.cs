using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public List<Guid>? SpecNameId { get; set; }
        public Guid? topcategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
    }
}
